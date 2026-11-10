using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VIZCore3DX.NET.Command.Chat
{
    // OpenAI 호환(Chat Completions 형식) 공급자입니다. 사내 LLM·로컬 LLM 서버처럼 같은 형식을 받는 주소면 그대로 쓸 수 있습니다.
    // 명령 목록은 tools(function) 로, 명령 호출은 tool_calls 로, 실행 결과는 role "tool" 메시지로 주고받습니다.
    internal class OpenAiProvider : ChatProvider
    {
        public const string DefaultEndpoint = "http://localhost:11434/v1/chat/completions";
        public const string DefaultModel = "";

        private readonly List<object> _messages = new List<object>();

        public override void Reset()
        {
            _messages.Clear();
        }

        public override void AddUser(string text)
        {
            _messages.Add(new Dictionary<string, object> { { "role", "user" }, { "content", text } });
        }

        public override void AddToolResult(ChatToolCall call, string content, bool isError)
        {
            _messages.Add(new Dictionary<string, object> { { "role", "tool" }, { "tool_call_id", call.Id }, { "content", content } });
        }

        public override async Task<ChatReply> SendAsync(string system, List<VIZCore3DX.NET.Data.CommandItem> tools)
        {
            // 안내문(system)은 기록에 넣지 않고 보낼 때마다 맨 앞에 붙입니다.
            List<object> messages = new List<object> { new Dictionary<string, object> { { "role", "system" }, { "content", system } } };
            messages.AddRange(_messages);

            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "model", Model }, { "messages", messages }, { "tools", ToTools(tools) }
            };
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(ApiKey) == false) headers.Add("Authorization", "Bearer " + ApiKey);

            Dictionary<string, object> response = await PostAsync(headers, body);

            // 응답 메시지는 받은 그대로 대화 기록에 넣습니다(명령 호출 정보가 들어 있습니다).
            IList choices = (IList)response["choices"];
            Dictionary<string, object> message = (Dictionary<string, object>)((Dictionary<string, object>)choices[0])["message"];
            _messages.Add(message);

            return ToReply(message);
        }

        // 명령 정의를 function 형식의 tool 정의로 바꿉니다. 인자 형식(JSON Schema)은 그대로 씁니다.
        private List<object> ToTools(List<VIZCore3DX.NET.Data.CommandItem> tools)
        {
            List<object> result = new List<object>();

            foreach (VIZCore3DX.NET.Data.CommandItem item in tools)
            {
                Dictionary<string, object> function = new Dictionary<string, object>
                {
                    { "name", item.Name }, { "description", item.Description }, { "parameters", Json.DeserializeObject(item.ParameterSchema) }
                };
                result.Add(new Dictionary<string, object> { { "type", "function" }, { "function", function } });
            }

            return result;
        }

        private static ChatReply ToReply(Dictionary<string, object> message)
        {
            ChatReply reply = new ChatReply();
            if (message.ContainsKey("content") && message["content"] is string) reply.Text = (string)message["content"];

            IEnumerable calls = message.ContainsKey("tool_calls") ? message["tool_calls"] as IEnumerable : null;
            if (calls == null) return reply;

            foreach (Dictionary<string, object> call in calls)
            {
                Dictionary<string, object> function = (Dictionary<string, object>)call["function"];
                reply.Calls.Add(new ChatToolCall { Id = call["id"] as string, Name = function["name"] as string, ArgumentsJson = function["arguments"] as string });
            }

            return reply;
        }
    }
}
