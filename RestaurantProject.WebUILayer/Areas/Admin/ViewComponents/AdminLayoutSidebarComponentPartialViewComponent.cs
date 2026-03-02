using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.Areas.Admin.ViewComponents
{
    public class AdminLayoutSidebarComponentPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
