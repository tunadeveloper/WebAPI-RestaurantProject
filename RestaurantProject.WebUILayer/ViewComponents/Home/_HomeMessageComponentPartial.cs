using Microsoft.AspNetCore.Mvc;
using RestaurantProject.WebUILayer.DTOs.MessageDTOs;

namespace RestaurantProject.WebUILayer.ViewComponents.Home
{
    public class _HomeMessageComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View(new CreateMessageDTO());
    }
}
