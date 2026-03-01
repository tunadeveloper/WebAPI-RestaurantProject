using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantProject.WebUILayer.DTOs.FeatureDTOs;
using System.Threading.Tasks;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeHeroComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeHeroComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7052/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDTO>>(jsonData);
                return View(values?.FirstOrDefault());
            }
            return View();
        }
    }
}
