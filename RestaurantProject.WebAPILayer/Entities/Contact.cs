using RestaurantProject.WebAPILayer.Entities.Common;

namespace RestaurantProject.WebAPILayer.Entities
{
    public class Contact:BaseEntity
    {
        public string ContactMapLocation { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactOpenTimes { get; set; }
    }
}
