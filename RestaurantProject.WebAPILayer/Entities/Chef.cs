using RestaurantProject.WebAPILayer.Entities.Common;

namespace RestaurantProject.WebAPILayer.Entities
{
    public class Chef:BaseEntity
    {
        public string ChefNameSurname { get; set; }
        public string ChefTitle { get; set; }
        public string ChefDescription { get; set; }
        public string ChefImageUrl { get; set; }
    }
}
