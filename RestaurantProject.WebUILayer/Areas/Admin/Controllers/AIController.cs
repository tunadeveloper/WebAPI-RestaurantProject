using Microsoft.AspNetCore.Mvc;
using RestaurantProject.WebUILayer.Areas.Admin.Models;
using System.Net.Http.Headers;

namespace RestaurantProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AIController : Controller
    {
        private readonly OpenAI _openAI;
        private readonly IHttpClientFactory _httpClientFactory;

        public AIController(IHttpClientFactory httpClientFactory, OpenAI openAI)
        {
            _httpClientFactory = httpClientFactory;
            _openAI = openAI;
        }

        public IActionResult CreateRecipe()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(string prompt)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _openAI.ApiKey);
            var requestData = new
            {
                model = _openAI.ModelName,
                messages = new[]
                {
                    new { role = "system", content = "Sen bir restoran için yemek önerileri yapan yapay zeka aracısın. Amacımız kullanıcı tarafından girilen malzemelere göre yemek tarifi önerisinde bulunmak." },
                    new { role = "user", content = prompt }
                },
                temperature = 0.5
            };
            var response = await client.PostAsJsonAsync($"{_openAI.BaseUrl}chat/completions", requestData);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                ViewBag.recipe = result.choices[0].message.content;
            }
            else
            {
                ViewBag.recipe = "Bir hata oluştu: " + response.StatusCode;
            }
            return View();
        }
    }
}
