using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantProject.WebUILayer.DTOs.CategoryDTOs;
using System.Threading.Tasks;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeMenuComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7052/api/Categories/{id}/products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
