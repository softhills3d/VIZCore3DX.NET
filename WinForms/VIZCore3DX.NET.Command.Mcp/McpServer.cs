using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace VIZCore3DX.NET.Command.Mcp
{
    // MCP(Model Context Protocol) 요청을 HTTP 로 받아 McpDispatcher 로 넘기는 최소 서버입니다.
    // POST /mcp 한 곳에서 JSON-RPC 2.0 요청을 받고 요청마다 JSON 응답 하나를 돌려줍니다(스트리밍 없음).
    // 127.0.0.1 에만 열리므로 같은 PC 의 AI 클라이언트만 접속할 수 있습니다.
    internal class McpServer
    {
        // 요청 본문 최대 크기. 명령 인자는 작으므로 비정상 요청만 막습니다.
        private const long MaxBodyBytes = 4 * 1024 * 1024;

        private readonly McpDispatcher _dispatcher;
        private HttpListener _listener;
        private volatile bool _running;

        public McpServer(McpDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public bool IsRunning { get { return _running; } }

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
            thread.Name = "VIZCore3DX-MCP";
            thread.Start(listener);
        }

        public void Stop()
        {
            if (!_running) return;

            _running = false;
            try { _listener.Close(); } catch { }
            _listener = null;
        }

        // 요청을 받은 순서대로 하나씩 처리합니다. 명령은 McpDispatcher 가 UI 스레드로 넘겨 실행합니다.
        private void Loop(object state)
        {
            HttpListener listener = (HttpListener)state;

            while (_running)
            {
                HttpListenerContext context;
                try { context = listener.GetContext(); }
                catch { break; }   // 서버가 멈췄습니다.

                Handle(context);
            }
        }

        private void Handle(HttpListenerContext context)
        {
            try
            {
                int status = Validate(context.Request);
                if (status != 200)
                {
                    context.Response.StatusCode = status;
                    context.Response.Close();
                    return;
                }

                string body;
                using (StreamReader reader = new StreamReader(context.Request.InputStream, Encoding.UTF8))
                    body = reader.ReadToEnd();

                string response = _dispatcher.Dispatch(body);

                // 응답이 필요 없는 알림(notification)은 본문 없이 202 로 답합니다.
                if (string.IsNullOrEmpty(response))
                {
                    context.Response.StatusCode = 202;
                    context.Response.Close();
                    return;
                }

                byte[] buffer = Encoding.UTF8.GetBytes(response);
                context.Response.StatusCode = 200;
                context.Response.ContentType = "application/json";
                context.Response.ContentLength64 = buffer.Length;
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.Close();
            }
            catch
            {
                // 요청 하나의 오류로 서버가 멈추지 않게 합니다.
                try { context.Response.StatusCode = 500; context.Response.Close(); } catch { }
            }
        }

        // 받을 수 있는 요청인지 확인하고 HTTP 상태 코드를 돌려줍니다(200 이면 처리).
        private static int Validate(HttpListenerRequest request)
        {
            string path = request.Url.AbsolutePath;
            if (path != "/mcp" && path != "/") return 404;

            // 웹 페이지가 브라우저를 통해 이 서버를 부르는 것을 막습니다. AI 클라이언트는 Origin 을 보내지 않습니다.
            if (!IsLocalOrigin(request.Headers["Origin"])) return 403;

            if (request.HttpMethod != "POST") return 405;
            if (request.ContentLength64 > MaxBodyBytes) return 413;

            return 200;
        }

        private static bool IsLocalOrigin(string origin)
        {
            if (string.IsNullOrEmpty(origin)) return true;

            Uri uri;
            if (!Uri.TryCreate(origin, UriKind.Absolute, out uri)) return false;

            return uri.Host == "127.0.0.1" || uri.Host == "localhost";
        }
    }
}
