using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeContactComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
