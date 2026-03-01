using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeStatsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
