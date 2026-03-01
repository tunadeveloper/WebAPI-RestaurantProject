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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var categoriesWithProducts = new List<ResultCategoryDTO>();
            var categoriesResponse = await client.GetAsync("https://localhost:7052/api/Categories");
            var categoriesJson = await categoriesResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(categoriesJson);

            foreach (var category in categories)
            {
                var productResponse = await client.GetAsync($"https://localhost:7052/api/Categories/{category.Id}/products");
                if (productResponse.IsSuccessStatusCode)
                {
                    var productJson = await productResponse.Content.ReadAsStringAsync();
                    var categoryWithProducts = JsonConvert.DeserializeObject<ResultCategoryDTO>(productJson);
                    categoriesWithProducts.Add(categoryWithProducts);
                }
            }

            return View(categoriesWithProducts);
        }
    }
}
