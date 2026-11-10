using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace VIZCore3DX.NET.Command.Chat
{
    // AI 가 요청한 명령 호출 하나입니다.
    internal class ChatToolCall
    {
        public string Id;
        public string Name;
        public string ArgumentsJson;
    }

    // AI 의 응답 한 번입니다. 글(Text)과 명령 호출(Calls)이 함께 올 수 있습니다.
    internal class ChatReply
    {
        public string Text = string.Empty;
        public List<ChatToolCall> Calls = new List<ChatToolCall>();
    }

    // AI(LLM) 공급자 하나를 감쌉니다. 공급자마다 요청·응답 형식이 달라 대화 기록도 각자 자기 형식으로 보관합니다.
    // 다른 공급자를 붙이려면 이 클래스를 상속해 네 메서드를 구현하면 됩니다.
    internal abstract class ChatProvider
    {
        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };

        protected readonly JavaScriptSerializer Json = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };

        public string Endpoint;
        public string Model;
        public string ApiKey;

        // 대화 기록을 비웁니다.
        public abstract void Reset();

        // 사용자의 말을 대화 기록에 더합니다.
        public abstract void AddUser(string text);

        // 명령 실행 결과를 대화 기록에 더합니다. 다음 SendAsync 때 AI 에 전달됩니다.
        public abstract void AddToolResult(ChatToolCall call, string content, bool isError);

        // 지금까지의 대화와 쓸 수 있는 명령 목록을 보내고 AI 의 응답을 받습니다.
        public abstract Task<ChatReply> SendAsync(string system, List<VIZCore3DX.NET.Data.CommandItem> tools);

        // JSON 요청을 보내고 JSON 응답을 받습니다. HTTP 오류는 응답 본문과 함께 예외로 알립니다.
        protected async Task<Dictionary<string, object>> PostAsync(Dictionary<string, string> headers, object body)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Endpoint);
            request.Content = new StringContent(Json.Serialize(body), Encoding.UTF8, "application/json");
            foreach (KeyValuePair<string, string> header in headers)
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);

            using (HttpResponseMessage response = await _http.SendAsync(request))
            {
                string text = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode == false)
                    throw new InvalidOperationException(string.Format("HTTP {0} : {1}", (int)response.StatusCode, text));

                return Json.Deserialize<Dictionary<string, object>>(text);
            }
        }
    }
}
