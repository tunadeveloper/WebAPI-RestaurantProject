namespace RestaurantProject.WebUILayer.DTOs.ChefDTOs
{
    public class UpdateChefDTO
    {
        public int Id { get; set; }
        public string ChefNameSurname { get; set; }
        public string ChefTitle { get; set; }
        public string ChefDescription { get; set; }
        public string ChefImageUrl { get; set; }
    }
}
