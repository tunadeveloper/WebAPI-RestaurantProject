namespace RestaurantProject.WebAPILayer.DTOs.FeatureDTOs
{
    public class UpdateFeatureDTO
    {
        public int Id { get; set; }
        public string FeatureSubtitle { get; set; }
        public string FeatureDescription { get; set; }
        public string FeatureImageUrl { get; set; }
        public string FeatureVideoUrl { get; set; }
    }
}
