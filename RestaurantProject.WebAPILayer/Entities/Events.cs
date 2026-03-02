using RestaurantProject.WebAPILayer.Entities.Common;

namespace RestaurantProject.WebAPILayer.Entities
{
    public class Events : BaseEntity
    {
        public string EventsTitle { get; set; }
        public string EventsDescription { get; set; }
        public string EventsImageUrl { get; set; }
        public bool EventsStatus { get; set; }
        public decimal EventsPrice { get; set; }
    }
}
