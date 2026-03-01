using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeChefsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
