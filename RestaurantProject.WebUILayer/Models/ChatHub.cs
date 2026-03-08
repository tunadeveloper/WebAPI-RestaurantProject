using Microsoft.AspNetCore.SignalR;
using RestaurantProject.WebUILayer.Areas.Admin.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestaurantProject.WebUILayer.Models
{
    public class ChatHub : Hub
    {
        private readonly OpenAI _openAI;
        private readonly IHttpClientFactory _httpClientFactor;

        public ChatHub(IHttpClientFactory httpClientFactor, OpenAI openAI)
        {
            _httpClientFactor = httpClientFactor;
            _openAI = openAI;
        }

        private static readonly Dictionary<string, List<Dictionary<string, string>>> _history = new();

        public override Task OnConnectedAsync()
        {
            _history[Context.ConnectionId] =
                [
                new()
                {
                    ["role"] = "system",
                    ["content"] = "You are a helpful assistant. Keep answers concise."
                }
                ];
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            _history.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            await Clients.Caller.SendAsync("ReceiveUserEcho", message);
            var history = _history[Context.ConnectionId];
            history.Add(new()
            {
                ["role"] = "user",
                ["content"] = message
            });
            await StreamOpenAI(history, Context.ConnectionAborted);
        }

        public async Task StreamOpenAI(List<Dictionary<string, string>> history, CancellationToken cancellationToken)
        {
            var client = _httpClientFactor.CreateClient("openai");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _openAI.ApiKey);
            var payload = new
            {
                model = _openAI.ModelName,
                messages = history,
                stream = true,
                temperature = 0.2
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, "chat/completions");
            request.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
            using var reader = new StreamReader(stream);

            var stringBuilder = new StringBuilder();
            while (!reader.EndOfStream && !cancellationToken.IsCancellationRequested)
            {
                var line = await reader.ReadLineAsync();
                if (string.IsNullOrEmpty(line)) continue;
                if (!line.StartsWith("data:")) continue;
                var data = line["data:".Length..].Trim();
                if (data == "[DONE]") break;

                try
                {
                    var chunk = JsonSerializer.Deserialize<ChatStreamChunk>(data);
                    var delta = chunk?.Choices?.FirstOrDefault()?.Delta?.Content;
                    if (!string.IsNullOrEmpty(delta))
                    {
                        stringBuilder.Append(delta);
                        await Clients.Caller.SendAsync("ReceiveToken", delta, cancellationToken);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            var full = stringBuilder.ToString();
            if (!string.IsNullOrEmpty(full))
            {
                history.Add(new()
                {
                    ["role"] = "assistant",
                    ["content"] = full
                });
                await Clients.Caller.SendAsync("CompleteMessage", full, cancellationToken);
            }
        }


        private sealed class ChatStreamChunk
        {
            [JsonPropertyName("choices")] public List<Choice> Choices { get; set; }
        }

        private sealed class Choice
        {
            [JsonPropertyName("delta")] public Delta? Delta { get; set; }
            [JsonPropertyName("finish_reason")] public string? FinishReason { get; set; }
        }

        private sealed class Delta
        {
            [JsonPropertyName("content")] public string? Content { get; set; }
            [JsonPropertyName("role")] public string? Role { get; set; }
        }
    }
}
