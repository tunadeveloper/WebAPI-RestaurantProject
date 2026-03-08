using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestaurantProject.WebUILayer.Areas.Admin.Models;
using RestaurantProject.WebUILayer.DTOs.ReservationDTOs;
using RestaurantProject.WebUILayer.DTOs.ProductDTOs;

namespace RestaurantProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private const string ApiBase = "https://localhost:7052/api";
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var model = new DashboardViewModel();

            model.ReservationsCount = await GetCountAsync(client, $"{ApiBase}/Reservations");
            model.ContactsCount = await GetCountAsync(client, $"{ApiBase}/Contacts");
            model.EventsCount = await GetCountAsync(client, $"{ApiBase}/Events");
            model.ProductsCount = await GetCountAsync(client, $"{ApiBase}/Products");
            model.CategoriesCount = await GetCountAsync(client, $"{ApiBase}/Categories");
            model.FeaturesCount = await GetCountAsync(client, $"{ApiBase}/Features");
            model.ServicesCount = await GetCountAsync(client, $"{ApiBase}/Services");
            model.TestimonialsCount = await GetCountAsync(client, $"{ApiBase}/Testimonials");
            model.ChefsCount = await GetCountAsync(client, $"{ApiBase}/Chefs");
            model.MessagesCount = await GetCountAsync(client, $"{ApiBase}/Messages");
            model.ImagesCount = await GetCountAsync(client, $"{ApiBase}/Images");

            model.Last7DaysReservations = await GetLast7DaysReservationsAsync(client);
            model.MonthlyReservations = await GetMonthlyReservationsAsync(client);
            model.ReservationStatusCounts = await GetReservationStatusCountsAsync(client);
            model.CategoryProductCounts = await GetCategoryProductCountsAsync(client);

            return View(model);
        }

        private static async Task<List<DailyReservationCount>> GetLast7DaysReservationsAsync(HttpClient client)
        {
            var list = new List<DailyReservationCount>();
            try
            {
                var response = await client.GetAsync($"{ApiBase}/Reservations");
                if (!response.IsSuccessStatusCode) return list;
                var json = await response.Content.ReadAsStringAsync();
                var reservations = JsonConvert.DeserializeObject<List<ResultReservationDTO>>(json);
                if (reservations == null) return list;

                var today = DateTime.Today;
                for (var i = 6; i >= 0; i--)
                {
                    var d = today.AddDays(-i);
                    var count = reservations.Count(r => r.ReservationDate.Date == d);
                    list.Add(new DailyReservationCount
                    {
                        DateLabel = d.ToString("dd MMM", new System.Globalization.CultureInfo("tr-TR")),
                        Count = count
                    });
                }
            }
            catch { }
            return list;
        }

        private static async Task<List<MonthlyReservationCount>> GetMonthlyReservationsAsync(HttpClient client)
        {
            var list = new List<MonthlyReservationCount>();
            try
            {
                var response = await client.GetAsync($"{ApiBase}/Reservations");
                if (!response.IsSuccessStatusCode) return list;
                var json = await response.Content.ReadAsStringAsync();
                var reservations = JsonConvert.DeserializeObject<List<ResultReservationDTO>>(json);
                if (reservations == null) return list;

                var ci = new System.Globalization.CultureInfo("tr-TR");
                var today = DateTime.Today;
                for (var i = 11; i >= 0; i--)
                {
                    var monthStart = new DateTime(today.Year, today.Month, 1).AddMonths(-i);
                    var monthEnd = monthStart.AddMonths(1);
                    var count = reservations.Count(r => r.ReservationDate >= monthStart && r.ReservationDate < monthEnd);
                    list.Add(new MonthlyReservationCount
                    {
                        MonthLabel = monthStart.ToString("MMM yyyy", ci),
                        Count = count
                    });
                }
            }
            catch { }
            return list;
        }

        private static async Task<List<ReservationStatusCount>> GetReservationStatusCountsAsync(HttpClient client)
        {
            var list = new List<ReservationStatusCount>();
            try
            {
                var response = await client.GetAsync($"{ApiBase}/Reservations");
                if (!response.IsSuccessStatusCode) return list;
                var json = await response.Content.ReadAsStringAsync();
                var reservations = JsonConvert.DeserializeObject<List<ResultReservationDTO>>(json);
                if (reservations == null) return list;

                var grouped = reservations
                    .GroupBy(r => string.IsNullOrEmpty(r.ReservationStatus) ? "Beklemede" : r.ReservationStatus)
                    .Select(g => new ReservationStatusCount { StatusName = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .ToList();
                return grouped;
            }
            catch { }
            return list;
        }

        private static async Task<List<CategoryProductCount>> GetCategoryProductCountsAsync(HttpClient client)
        {
            var list = new List<CategoryProductCount>();
            try
            {
                var response = await client.GetAsync($"{ApiBase}/Products/ProductListWithCategory");
                if (!response.IsSuccessStatusCode)
                    response = await client.GetAsync($"{ApiBase}/Products");
                if (!response.IsSuccessStatusCode) return list;
                var json = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ResultProductDTO>>(json);
                if (products == null) return list;

                var grouped = products
                    .GroupBy(p => string.IsNullOrEmpty(p.CategoryName) ? "Kategorisiz" : p.CategoryName)
                    .Select(g => new CategoryProductCount { CategoryName = g.Key, ProductCount = g.Count() })
                    .OrderByDescending(x => x.ProductCount)
                    .ToList();
                return grouped;
            }
            catch { }
            return list;
        }

        private static async Task<int> GetCountAsync(HttpClient client, string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode) return 0;
                var json = await response.Content.ReadAsStringAsync();
                var arr = JArray.Parse(json);
                return arr?.Count ?? 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
