using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantProject.WebUILayer.DTOs.MessageDTOs;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.WebUILayer.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDTO createMessageDTO)
        {
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
