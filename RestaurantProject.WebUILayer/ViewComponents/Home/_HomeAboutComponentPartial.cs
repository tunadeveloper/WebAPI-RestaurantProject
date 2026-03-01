using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeAboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
