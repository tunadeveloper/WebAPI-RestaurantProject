using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeGalleryComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
