using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeMenuComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
