using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantProject.WebUILayer.DTOs.ReservationDTOs;
using System.Text;

namespace RestaurantProject.WebUILayer.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDTO createReservationDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responeMessage = await client.PostAsync("https://localhost:7052/api/Reservations", content);
            if (responeMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Home");
            return View();
        }
    }
}
