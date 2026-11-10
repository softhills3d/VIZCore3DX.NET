using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace VIZCore3DX.NET.Command.Mcp
{
    // JSON-RPC 2.0 요청 하나를 받아 명령 계층(vizcore3dx.Command)을 부르고 JSON 응답을 만듭니다.
    // MCP 중 도구 호출에 필요한 최소 범위만 다룹니다 : initialize · ping · tools/list · tools/call
    //
    //   tools/list  →  Command.GetCommands()        (이름·설명·인자 형식·조회 여부)
    //   tools/call  →  Command.Execute(이름, 인자)   (결과 JSON 또는 실패 사유)
    internal class McpDispatcher
    {
        private const int ParseError = -32700;
        private const int InvalidRequest = -32600;
        private const int MethodNotFound = -32601;
        private const int InvalidParams = -32602;

        // 이 서버가 지원하는 MCP 프로토콜 버전. 클라이언트가 모르는 버전을 보내면 기본 버전으로 답합니다.
        private const string DefaultProtocolVersion = "2025-06-18";
        private static readonly string[] SupportedProtocolVersions = { "2025-06-18", "2025-03-26" };

        private readonly VIZCore3DX.NET.VIZCore3DXControl _vizcore3dx;
        private readonly JavaScriptSerializer _json = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };

        public McpDispatcher(VIZCore3DX.NET.VIZCore3DXControl vizcore3dx)
        {
            _vizcore3dx = vizcore3dx;
        }

        // true 면 조회 명령만 공개합니다. 변경 명령은 목록에서 빠지고 호출해도 거절됩니다.
        public bool ReadOnlyOnly { get; set; }

        // 처리한 요청을 한 줄로 알립니다. 서버 스레드에서 발생합니다.
        public event Action<string> Log;

        // 요청 본문 하나를 처리해 응답 JSON 을 돌려줍니다. 응답이 필요 없는 알림이면 null 입니다.
        public string Dispatch(string body)
        {
            Dictionary<string, object> request;
            try { request = _json.Deserialize<Dictionary<string, object>>(body); }
            catch (Exception ex) { return Error(null, ParseError, "Parse error: " + ex.Message); }

            if (request == null) return Error(null, InvalidRequest, "Empty request");

            // "id" 가 없는 요청은 알림이므로 응답하지 않습니다.
            bool isNotification = !request.ContainsKey("id");
            object id = isNotification ? null : request["id"];
            string method = request.ContainsKey("method") ? request["method"] as string : null;
            IDictionary<string, object> parameters = request.ContainsKey("params") ? request["params"] as IDictionary<string, object> : null;

            object result;
            switch (method)
            {
                case "initialize": result = Initialize(parameters); break;
                case "ping": result = new Dictionary<string, object>(); break;
                case "tools/list": result = ListTools(); break;
                case "tools/call": result = CallTool(parameters); break;
                default:
                    return isNotification ? null : Error(id, MethodNotFound, "Method not found: " + method);
            }

            if (isNotification) return null;
            if (result == null) return Error(id, InvalidParams, "Missing tool name");

            return _json.Serialize(new Dictionary<string, object> { { "jsonrpc", "2.0" }, { "id", id }, { "result", result } });
        }

        // 서버 정보와 사용 안내문을 돌려줍니다. 안내문은 SDK 가 주는 명령 조합법입니다.
        private object Initialize(IDictionary<string, object> parameters)
        {
            string protocol = DefaultProtocolVersion;
            string requested = parameters != null && parameters.ContainsKey("protocolVersion") ? parameters["protocolVersion"] as string : null;
            if (Array.IndexOf(SupportedProtocolVersions, requested) >= 0) protocol = requested;

            WriteLog("initialize");

            return new Dictionary<string, object>
            {
                { "protocolVersion", protocol },
                { "capabilities", new Dictionary<string, object> { { "tools", new Dictionary<string, object> { { "listChanged", false } } } } },
                { "serverInfo", new Dictionary<string, object> { { "name", "VIZCore3DX.NET" }, { "version", VIZCore3DX.NET.ModuleInitializer.GetLibraryVersion() } } },
                { "instructions", OnUi(() => _vizcore3dx.Command.GetGuide()) }
            };
        }

        // 명령 목록을 MCP 도구 목록 형식으로 바꿉니다.
        private object ListTools()
        {
            List<object> tools = new List<object>();

            foreach (VIZCore3DX.NET.Data.CommandItem item in OnUi(() => _vizcore3dx.Command.GetCommands()))
            {
                if (ReadOnlyOnly && item.IsReadOnly == false) continue;

                tools.Add(new Dictionary<string, object>
                {
                    { "name", item.Name },
                    { "description", item.Description },
                    { "inputSchema", _json.DeserializeObject(item.ParameterSchema) },
                    { "annotations", new Dictionary<string, object> { { "readOnlyHint", item.IsReadOnly } } }
                });
            }

            WriteLog(string.Format("tools/list : {0}개", tools.Count));

            return new Dictionary<string, object> { { "tools", tools } };
        }

        // 명령을 실행합니다. 실패는 프로토콜 오류가 아니라 isError 결과로 알려 AI 가 사유를 읽고 고치게 합니다.
        private object CallTool(IDictionary<string, object> parameters)
        {
            string name = parameters != null && parameters.ContainsKey("name") ? parameters["name"] as string : null;
            if (string.IsNullOrEmpty(name)) return null;

            if (ReadOnlyOnly && IsReadOnly(name) == false)
            {
                WriteLog(string.Format("tools/call {0} : 거절(조회 명령만 공개)", name));
                return ToolResult(TextContent("This command changes the view and is disabled. Only read-only commands are available."), true);
            }

            // 어느 스레드에서 불러도 명령은 UI 스레드에서 실행되고, 오류는 예외 대신 실패 결과로 돌아옵니다.
            object arguments = parameters.ContainsKey("arguments") ? parameters["arguments"] : null;
            VIZCore3DX.NET.Data.CommandResult result = _vizcore3dx.Command.Execute(name, arguments == null ? null : _json.Serialize(arguments));

            WriteLog(string.Format("tools/call {0} : {1}", name, result.Success ? "성공" : "실패 - " + result.ErrorMessage));

            if (result.Success == false) return ToolResult(TextContent(result.ErrorMessage), true);
            if (name == "capture_screenshot") return ToolResult(ImageContent(result.Json), false);

            return ToolResult(TextContent(result.Json), false);
        }

        private bool IsReadOnly(string name)
        {
            VIZCore3DX.NET.Data.CommandItem item = OnUi(() => _vizcore3dx.Command.GetCommands()).Find(x => x.Name == name);

            return item != null && item.IsReadOnly;
        }

        private static object ToolResult(object content, bool isError)
        {
            return new Dictionary<string, object> { { "content", new List<object> { content } }, { "isError", isError } };
        }

        private static object TextContent(string text)
        {
            return new Dictionary<string, object> { { "type", "text" }, { "text", text } };
        }

        // 화면 캡처 결과 { mimeType, data(base64) } 를 MCP 이미지 형식으로 바꿉니다.
        private object ImageContent(string json)
        {
            Dictionary<string, object> image = _json.Deserialize<Dictionary<string, object>>(json);

            return new Dictionary<string, object> { { "type", "image" }, { "data", image["data"] }, { "mimeType", image["mimeType"] } };
        }

        private string Error(object id, int code, string message)
        {
            Dictionary<string, object> error = new Dictionary<string, object> { { "code", code }, { "message", message } };

            return _json.Serialize(new Dictionary<string, object> { { "jsonrpc", "2.0" }, { "id", id }, { "error", error } });
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
