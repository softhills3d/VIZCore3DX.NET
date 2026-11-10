using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VIZCore3DX.NET.Command.Chat
{
    // Claude (Anthropic Messages API) 공급자입니다.
    // 명령 목록은 tools 로, 명령 호출은 tool_use 블록으로, 실행 결과는 tool_result 블록으로 주고받습니다.
    internal class ClaudeProvider : ChatProvider
    {
        public const string DefaultEndpoint = "https://api.anthropic.com/v1/messages";
        public const string DefaultModel = "claude-opus-5-5";

        private readonly List<object> _messages = new List<object>();
        private readonly List<object> _results = new List<object>();

        public override void Reset()
        {
            _messages.Clear();
            _results.Clear();
        }

        public override void AddUser(string text)
        {
            FlushResults();
            _messages.Add(new Dictionary<string, object> { { "role", "user" }, { "content", text } });
        }

        public override void AddToolResult(ChatToolCall call, string content, bool isError)
        {
            _results.Add(new Dictionary<string, object>
            {
                { "type", "tool_result" }, { "tool_use_id", call.Id }, { "content", content }, { "is_error", isError }
            });
        }

        public override async Task<ChatReply> SendAsync(string system, List<VIZCore3DX.NET.Data.CommandItem> tools)
        {
            FlushResults();

            Dictionary<string, object> body = new Dictionary<string, object>
            {
                { "model", Model },
                { "max_tokens", 16000 },
                { "system", system },
                { "tools", ToTools(tools) },
                { "messages", _messages },
                // 안전 분류기가 요청을 거절하면 서버가 다른 모델로 이어서 응답합니다.
                { "fallbacks", "default" }
            };
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "x-api-key", ApiKey },
                { "anthropic-version", "2026-10-21" },
                { "anthropic-beta", "server-side-fallback-2026-07-01" }
            };

            Dictionary<string, object> response = await PostAsync(headers, body);

            // 응답 내용은 받은 그대로 대화 기록에 넣습니다(글·명령 호출·생각 블록을 빼거나 고치지 않습니다).
            IEnumerable content = (IEnumerable)response["content"];
            _messages.Add(new Dictionary<string, object> { { "role", "assistant" }, { "content", content } });

            ChatReply reply = ToReply(content);
            if (response["stop_reason"] as string == "refusal") reply.Text += "(AI 가 이 요청을 거절했습니다.)";

            return reply;
        }

        // 한 응답의 명령 실행 결과는 모두 모아 user 메시지 하나로 보냅니다.
        private void FlushResults()
        {
            if (_results.Count == 0) return;

            _messages.Add(new Dictionary<string, object> { { "role", "user" }, { "content", _results.ToArray() } });
            _results.Clear();
        }

        // 명령 정의를 Claude 의 tool 정의로 바꿉니다. 인자 형식(JSON Schema)은 그대로 씁니다.
        private List<object> ToTools(List<VIZCore3DX.NET.Data.CommandItem> tools)
        {
            List<object> result = new List<object>();

            foreach (VIZCore3DX.NET.Data.CommandItem item in tools)
            {
                result.Add(new Dictionary<string, object>
                {
                    { "name", item.Name }, { "description", item.Description }, { "input_schema", Json.DeserializeObject(item.ParameterSchema) }
                });
            }

            return result;
        }

        private ChatReply ToReply(IEnumerable content)
        {
            ChatReply reply = new ChatReply();

            foreach (Dictionary<string, object> block in content)
            {
                string type = block["type"] as string;

                if (type == "text") reply.Text += block["text"] as string;
                if (type == "tool_use")
                    reply.Calls.Add(new ChatToolCall { Id = block["id"] as string, Name = block["name"] as string, ArgumentsJson = Json.Serialize(block["input"]) });
            }

            return reply;
        }
    }
}
