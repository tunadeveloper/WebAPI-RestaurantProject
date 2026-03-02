using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.Areas.Admin.ViewComponents
{
    public class AdminLayoutHeadComponentPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
