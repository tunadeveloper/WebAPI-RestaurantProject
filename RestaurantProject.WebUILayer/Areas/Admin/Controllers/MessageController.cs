using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantProject.WebUILayer.Areas.Admin.Models;
using RestaurantProject.WebUILayer.DTOs.MessageDTOs;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly OpenAI _openAI;
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory, OpenAI openAI)
        {
            _httpClientFactory = httpClientFactory;
            _openAI = openAI;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7052/api/Messages");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7052/api/Messages/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Message", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> UpdateMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7052/api/Messages/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<ResultMessageDTO>(jsonData);
                return View(item);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7052/api/Messages", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Message", new { area = "Admin" });
            }
            return View();
        }

        public IActionResult CreateMessage() => View();

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7052/api/Messages", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Message", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> AnswerMessageWithOpenAI(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7052/api/Messages/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultMessageDTO>(jsonData);
            var messageText = values?.MessageDetails;

            if (Request.Method == "POST")
            {
                var openAIClient = _httpClientFactory.CreateClient();
                openAIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _openAI.ApiKey);
                var requestData = new
                {
                    model = _openAI.ModelName,
                    messages = new[]
                    {
                        new { role = "system", content = "Sen bir restoran için kullanıcıların gönderrmiş olduğu mesajları detaylı ve oldukça olumlu, müşteri memnuniyeti gözeten cevaplar veren bir yapay zeka aracısın. Amacımız kullanıcı tarafından gönderilen mesajlara en olumlu ve mantıklı cevapları sunabilmek." },
                        new { role = "user", content = messageText }
                    },
                    temperature = 0.5
                };
                var response = await openAIClient.PostAsJsonAsync($"{_openAI.BaseUrl}chat/completions", requestData);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                    ViewBag.answerAI = result.choices[0].message.content;
                }
                else
                {
                    ViewBag.answerAI = "Bir hata oluştu: " + response.StatusCode;
                }
            }

            return View(values);
        }
    }
}
