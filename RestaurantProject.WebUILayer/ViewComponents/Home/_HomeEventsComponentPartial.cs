using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeEventsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
