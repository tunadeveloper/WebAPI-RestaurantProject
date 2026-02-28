using Microsoft.AspNetCore.Mvc;
using RestaurantProject.WebUILayer.Models;
using System.Diagnostics;

namespace RestaurantProject.WebUILayer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
