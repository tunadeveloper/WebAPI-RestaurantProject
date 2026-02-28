using RestaurantProject.WebAPILayer.Entities.Common;

namespace RestaurantProject.WebAPILayer.Entities
{
    public class Image:BaseEntity
    {
        public string ImageTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
