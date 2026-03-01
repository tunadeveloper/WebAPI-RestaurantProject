using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeBookATableComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
