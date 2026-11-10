using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace VIZCore3DX.NET.Command.WebSocket
{
    // 웹 페이지가 WebSocket 으로 보낸 요청을 명령 계층(vizcore3dx.Command)으로 넘기는 최소 서버입니다.
    // 127.0.0.1 에만 열리고, http://127.0.0.1:포트/ 로 접속하면 시험용 페이지(client.html)를 보여 줍니다.
    //
    //   요청  { "id": 1, "type": "execute", "name": "select_by_name", "arguments": { "name": "PIPE" } }
    //         { "id": 2, "type": "catalog" }      명령 목록
    //         { "id": 3, "type": "context" }      상태 요약(열린 모델·선택·카메라)
    //   응답  { "id": 1, "success": true, "result": <결과 JSON>, "error": null }
    internal class WebSocketServer
    {
        // 메시지 하나의 최대 크기. 명령 인자는 작으므로 비정상 요청만 막습니다.
        private const int MaxMessageBytes = 4 * 1024 * 1024;

        private readonly VIZCore3DX.NET.VIZCore3DXControl _vizcore3dx;
        private readonly JavaScriptSerializer _json = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
        private readonly List<System.Net.WebSockets.WebSocket> _sockets = new List<System.Net.WebSockets.WebSocket>();
        private HttpListener _listener;
        private volatile bool _running;

        public WebSocketServer(VIZCore3DX.NET.VIZCore3DXControl vizcore3dx)
        {
            _vizcore3dx = vizcore3dx;
        }

        public bool IsRunning { get { return _running; } }

        // true 면 조회 명령만 받습니다. 변경 명령은 거절됩니다.
        public bool ReadOnlyOnly { get; set; }

        // 접속·요청을 한 줄로 알립니다. UI 스레드가 아닌 곳에서 발생합니다.
        public event Action<string> Log;

        // 서버를 시작합니다. 포트를 이미 다른 프로그램이 쓰고 있으면 HttpListenerException 이 납니다.
        public void Start(int port)
        {
            if (_running) return;

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.1:" + port + "/");
            listener.Start();

            _listener = listener;
            _running = true;

            Thread thread = new Thread(Loop);
            thread.IsBackground = true;
            thread.Name = "VIZCore3DX-WebSocket";
            thread.Start(listener);
        }

        // 서버를 멈추고 접속해 있는 페이지를 모두 끊습니다.
        public void Stop()
        {
            if (!_running) return;

            _running = false;
            try { _listener.Close(); } catch { }
            _listener = null;

            lock (_sockets)
            {
                foreach (System.Net.WebSockets.WebSocket socket in _sockets) socket.Abort();
                _sockets.Clear();
            }
        }

        private void Loop(object state)
        {
            HttpListener listener = (HttpListener)state;

            while (_running)
            {
                HttpListenerContext context;
                try { context = listener.GetContext(); }
                catch { break; }   // 서버가 멈췄습니다.

                if (context.Request.IsWebSocketRequest) AcceptAsync(context);
                else ServePage(context);
            }
        }

        // WebSocket 접속 하나를 받아, 끊길 때까지 요청을 처리합니다. 여러 페이지가 동시에 접속할 수 있습니다.
        private async void AcceptAsync(HttpListenerContext context)
        {
            // 다른 사이트의 웹 페이지가 이 서버에 접속하는 것을 막습니다.
            if (!IsLocalOrigin(context.Request.Headers["Origin"]))
            {
                context.Response.StatusCode = 403;
                context.Response.Close();
                return;
            }

            System.Net.WebSockets.WebSocket socket = null;
            try
            {
                socket = (await context.AcceptWebSocketAsync(null).ConfigureAwait(false)).WebSocket;
                lock (_sockets) _sockets.Add(socket);
                WriteLog("접속");

                while (socket.State == System.Net.WebSockets.WebSocketState.Open)
                {
                    string request = await ReceiveAsync(socket).ConfigureAwait(false);
                    if (request == null) break;

                    byte[] response = Encoding.UTF8.GetBytes(Handle(request));
                    await socket.SendAsync(new ArraySegment<byte>(response), System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None).ConfigureAwait(false);
                }
            }
            catch
            {
                // 접속 하나의 오류로 서버가 멈추지 않게 합니다.
            }

            if (socket == null) return;

            lock (_sockets) _sockets.Remove(socket);
            socket.Abort();
            WriteLog("접속 종료");
        }

        // 텍스트 메시지 하나를 끝까지 받습니다. 접속이 닫히거나 너무 큰 메시지면 null 입니다.
        private static async Task<string> ReceiveAsync(System.Net.WebSockets.WebSocket socket)
        {
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8192]);

            using (MemoryStream stream = new MemoryStream())
            {
                while (true)
                {
                    System.Net.WebSockets.WebSocketReceiveResult received = await socket.ReceiveAsync(buffer, CancellationToken.None).ConfigureAwait(false);
                    if (received.MessageType == System.Net.WebSockets.WebSocketMessageType.Close) return null;

                    stream.Write(buffer.Array, 0, received.Count);
                    if (stream.Length > MaxMessageBytes) return null;
                    if (received.EndOfMessage) return Encoding.UTF8.GetString(stream.ToArray());
                }
            }
        }

        // 요청 JSON 하나를 처리해 응답 JSON 을 만듭니다.
        private string Handle(string requestJson)
        {
            Dictionary<string, object> request;
            try { request = _json.Deserialize<Dictionary<string, object>>(requestJson); }
            catch (Exception ex) { return Response(null, false, "null", "요청이 JSON 개체가 아닙니다: " + ex.Message); }

            if (request == null) return Response(null, false, "null", "빈 요청입니다.");

            object id = request.ContainsKey("id") ? request["id"] : null;
            string type = request.ContainsKey("type") ? request["type"] as string : "execute";
            string name = request.ContainsKey("name") ? request["name"] as string : null;

            if (type == "catalog") return Response(id, true, OnUi(() => _vizcore3dx.Command.GetCatalog()), null);
            if (type == "context") return Response(id, true, OnUi(() => _vizcore3dx.Command.GetContext()), null);
            if (type != "execute") return Response(id, false, "null", "알 수 없는 type 입니다: " + type);

            if (ReadOnlyOnly && IsReadOnly(name) == false)
            {
                WriteLog(string.Format("{0} : 거절(조회 명령만 받기)", name));
                return Response(id, false, "null", "변경 명령은 받지 않도록 설정되어 있습니다.");
            }

            // 어느 스레드에서 불러도 명령은 UI 스레드에서 실행되고, 오류는 예외 대신 실패 결과로 돌아옵니다.
            object arguments = request.ContainsKey("arguments") ? request["arguments"] : null;
            VIZCore3DX.NET.Data.CommandResult result = _vizcore3dx.Command.Execute(name, arguments == null ? null : _json.Serialize(arguments));

            WriteLog(string.Format("{0} : {1}", name, result.Success ? "성공" : "실패 - " + result.ErrorMessage));

            return Response(id, result.Success, result.Json, result.ErrorMessage);
        }

        // 결과 JSON 은 다시 풀지 않고 그대로 응답에 끼워 넣습니다.
        private string Response(object id, bool success, string resultJson, string error)
        {
            return "{\"id\":" + _json.Serialize(id) + ",\"success\":" + (success ? "true" : "false") + ",\"result\":" + resultJson + ",\"error\":" + _json.Serialize(error) + "}";
        }

        private bool IsReadOnly(string name)
        {
            VIZCore3DX.NET.Data.CommandItem item = OnUi(() => _vizcore3dx.Command.GetCommands()).Find(x => x.Name == name);

            return item != null && item.IsReadOnly;
        }

        // 시험용 페이지(실행 파일 옆의 client.html)를 보여 줍니다.
        private static void ServePage(HttpListenerContext context)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "client.html");
                if (context.Request.Url.AbsolutePath != "/" || !File.Exists(path))
                {
                    context.Response.StatusCode = 404;
                    context.Response.Close();
                    return;
                }

                byte[] buffer = File.ReadAllBytes(path);
                context.Response.ContentType = "text/html; charset=utf-8";
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.Close();
            }
            catch
            {
                try { context.Response.Abort(); } catch { }
            }
        }

        private static bool IsLocalOrigin(string origin)
        {
            if (string.IsNullOrEmpty(origin)) return true;   // 브라우저가 아닌 프로그램

            Uri uri;
            if (!Uri.TryCreate(origin, UriKind.Absolute, out uri)) return false;

            return uri.Host == "127.0.0.1" || uri.Host == "localhost";
        }

        // 뷰어에 접근하는 코드는 UI 스레드에서 실행합니다.
        private T OnUi<T>(Func<T> func)
        {
            if (_vizcore3dx.InvokeRequired) return (T)_vizcore3dx.Invoke(func);

            return func();
        }

        private void WriteLog(string message)
        {
            Action<string> handler = Log;
            if (handler != null) handler(message);
        }
    }
}
