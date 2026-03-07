using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace RestaurantProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AIController : Controller
    {
        private const string apiKey = "";

        private readonly IHttpClientFactory _httpClientFactory;

        public AIController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult CreateRecipe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(string prompt)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[] {
                    new
                    {
                        role = "system",
                        content="Sen bir restoran için yemek önerilieri yapan yapay zeka aracısın. Amacımız kullanıcı tarafından girilen malzemelere göre yemek tarifi önerisinde bulunmak."
                    },
                    new
                    {
                        role = "user",
                        content = prompt
                    }
                },
                temperature= 0.5
            };

            var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                var content = result.choices[0].message.content;
                ViewBag.recipe = content;
            }
            else
            {
                ViewBag.recipe = "Bir hata oluştu: " + response.StatusCode;
            }
            return View();
        }



        public class OpenAIResponse
        {
            public List<Choice> choices { get; set; }
        }

        public class Choice
        {
            public Message message { get; set; }
        }

        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }
    }
}
