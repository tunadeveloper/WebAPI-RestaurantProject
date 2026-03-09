using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestaurantProject.WebUILayer.Areas.Admin.Models;
using RestaurantProject.WebUILayer.DTOs.ReservationDTOs;
using RestaurantProject.WebUILayer.DTOs.ProductDTOs;
using System.Globalization;

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
            var ci = new CultureInfo("tr-TR");

            var resJson = await (await client.GetAsync($"{ApiBase}/Reservations")).Content.ReadAsStringAsync();
            var reservations = JsonConvert.DeserializeObject<List<ResultReservationDTO>>(resJson);
            model.ReservationsCount = reservations.Count;

            var prodJson = await (await client.GetAsync($"{ApiBase}/Products")).Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDTO>>(prodJson);
            model.ProductsCount = products.Count;

            var catJson = await (await client.GetAsync($"{ApiBase}/Categories")).Content.ReadAsStringAsync();
            model.CategoriesCount = JArray.Parse(catJson).Count;

            var msgJson = await (await client.GetAsync($"{ApiBase}/Messages")).Content.ReadAsStringAsync();
            model.MessagesCount = JArray.Parse(msgJson).Count;

            var today = DateTime.Today;
            model.Last7DaysReservations = Enumerable.Range(-6, 7).Select(i =>
            {
                var d = today.AddDays(i);
                return new DailyReservationCount
                {
                    DateLabel = d.ToString("dd MMM", ci),
                    Count = reservations.Count(r => r.ReservationDate.Date == d)
                };
            }).ToList();

            model.MonthlyReservations = Enumerable.Range(-11, 12).Select(i =>
            {
                var monthStart = new DateTime(today.Year, today.Month, 1).AddMonths(i);
                var monthEnd = monthStart.AddMonths(1);
                return new MonthlyReservationCount
                {
                    MonthLabel = monthStart.ToString("MMM yyyy", ci),
                    Count = reservations.Count(r => r.ReservationDate >= monthStart && r.ReservationDate < monthEnd)
                };
            }).ToList();

            model.ReservationStatusCounts = reservations
                .GroupBy(r => string.IsNullOrEmpty(r.ReservationStatus) ? "Beklemede" : r.ReservationStatus)
                .Select(g => new ReservationStatusCount { StatusName = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();

            var productsWithCategory = await client.GetAsync($"{ApiBase}/Products/ProductListWithCategory");
            var productsWithCatJson = await productsWithCategory.Content.ReadAsStringAsync();
            var productsForCategory = JsonConvert.DeserializeObject<List<ResultProductDTO>>(productsWithCatJson) ?? products;
            model.CategoryProductCounts = productsForCategory
                .GroupBy(p => string.IsNullOrEmpty(p.CategoryName) ? "Kategorisiz" : p.CategoryName)
                .Select(g => new CategoryProductCount { CategoryName = g.Key, ProductCount = g.Count() })
                .OrderByDescending(x => x.ProductCount)
                .ToList();

            return View(model);
        }
    }
}
