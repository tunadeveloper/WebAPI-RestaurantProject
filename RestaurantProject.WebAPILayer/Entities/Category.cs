using RestaurantProject.WebAPILayer.Entities.Common;

namespace RestaurantProject.WebAPILayer.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
