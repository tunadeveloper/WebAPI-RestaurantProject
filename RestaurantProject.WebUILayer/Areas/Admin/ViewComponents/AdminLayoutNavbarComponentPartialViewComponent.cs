using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.Areas.Admin.ViewComponents
{
    public class AdminLayoutNavbarComponentPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
