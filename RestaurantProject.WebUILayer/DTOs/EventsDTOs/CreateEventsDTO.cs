namespace RestaurantProject.WebUILayer.DTOs.EventsDTOs
{
    public class CreateEventsDTO
    {
        public string EventsTitle { get; set; }
        public string EventsDescription { get; set; }
        public string EventsImageUrl { get; set; }
        public bool EventsStatus { get; set; }
        public decimal EventsPrice { get; set; }
    }
}
