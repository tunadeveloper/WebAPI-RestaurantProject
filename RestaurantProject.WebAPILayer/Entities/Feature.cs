using RestaurantProject.WebAPILayer.Entities.Common;

namespace RestaurantProject.WebAPILayer.Entities
{
    public class Feature:BaseEntity
    {
        public string FeatureSubtitle { get; set; }
        public string FeatureDescription { get; set; }
        public string FeatureImageUrl { get; set; }
        public string FeatureVideoUrl { get; set; }
    }
}
