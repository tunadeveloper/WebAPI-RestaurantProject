using Microsoft.AspNetCore.Mvc;

namespace RestaurantProject.WebUILayer.Areas.Admin.Controllers
{
    public class ChatController : Controller
    {
        [Area("Admin")]
        public IActionResult SendChatWithAI()
        {
            return View();
        }
    }
}
