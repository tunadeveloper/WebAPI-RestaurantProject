using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeHeroComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
