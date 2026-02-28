using RestaurantProject.WebAPILayer.Entities.Common;

namespace RestaurantProject.WebAPILayer.Entities
{
    public class Service : BaseEntity
    {
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceIconUrl { get; set; }
    }
}
