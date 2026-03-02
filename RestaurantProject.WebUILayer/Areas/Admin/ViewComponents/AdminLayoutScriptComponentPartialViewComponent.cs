using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.Areas.Admin.ViewComponents
{
    public class AdminLayoutScriptComponentPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
