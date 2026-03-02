using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantProject.WebUILayer.DTOs.ReservationDTOs;
using System.Threading.Tasks;

namespace RestaurantProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7052/api/Reservations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReservationDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
