using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantProject.WebUILayer.DTOs.ImageDTOs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7052/api/Images");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultImageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteImage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7052/api/Images/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Image", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> UpdateImage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7052/api/Images/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<ResultImageDTO>(jsonData);
                return View(item);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateImage(UpdateImageDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7052/api/Images", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Image", new { area = "Admin" });
            }
            return View();
        }

        public IActionResult CreateImage() => View();

        [HttpPost]
        public async Task<IActionResult> CreateImage(CreateImageDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7052/api/Images", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Image", new { area = "Admin" });
            }
            return View();
        }
    }
}
