using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantProject.WebUILayer.Areas.Admin.Models;
using RestaurantProject.WebUILayer.DTOs.MessageDTOs;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace RestaurantProject.WebUILayer.Controllers
{
    public class MessageController : Controller
    {
        private readonly OpenAI _openAI;
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory, OpenAI openAI)
        {
            _httpClientFactory = httpClientFactory;
            _openAI = openAI;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDTO createMessageDTO)
        {
            var aiClient = _httpClientFactory.CreateClient();
            aiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _openAI.ApiKey);

            var requestBody = new
            {
                model = _openAI.ModelName,
                messages = new[]
            {
            new { role = "system", content = "Translate the following Turkish text to English." },
            new { role = "user", content = createMessageDTO.MessageDetails }
                }
            };

            var translateJson = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var translateContent = new StringContent(translateJson, Encoding.UTF8, "application/json");
            var translateResponse = await aiClient.PostAsync($"{_openAI.BaseUrl}chat/completions", translateContent);
            var translateResponseString = await translateResponse.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(translateResponseString);
            var englishText = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();
            createMessageDTO.MessageDetails = englishText;

            var toxicRequestBody = new
            {
                model = "omni-moderation-latest",
                input = englishText
            };
            var toxicJson = System.Text.Json.JsonSerializer.Serialize(toxicRequestBody);
            var toxicContent = new StringContent(toxicJson, Encoding.UTF8, "application/json");
            var toxicResponse = await aiClient.PostAsync($"{_openAI.BaseUrl}moderations", toxicContent);
            var toxicResponseString = await toxicResponse.Content.ReadAsStringAsync();
            var toxicDoc = JsonDocument.Parse(toxicResponseString);

            var result = toxicDoc.RootElement.GetProperty("results")[0];
            var categories = result.GetProperty("categories");

            createMessageDTO.MessageStatus =
                !result.GetProperty("flagged").GetBoolean() ? "Temiz İçerik" :
                categories.GetProperty("harassment").GetBoolean() ? "Hakaret İçerici" :
                categories.GetProperty("violence").GetBoolean() ? "Şiddet İçerici" :
                categories.GetProperty("hate").GetBoolean() ? "Nefret İçerici" : "Toksik İçerik";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responeMessage = await client.PostAsync("https://localhost:7052/api/Messages", content);
            if (responeMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Home");
            return View();
        }
    }
}
