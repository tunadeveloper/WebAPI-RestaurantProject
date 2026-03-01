using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantProject.WebUILayer.DTOs.ServiceDTOs;
using System.Threading.Tasks;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeWhyUsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeWhyUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7052/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
