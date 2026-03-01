using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeWhyUsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
