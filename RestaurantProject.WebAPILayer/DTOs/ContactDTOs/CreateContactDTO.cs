namespace RestaurantProject.WebAPILayer.DTOs.ContactDTOs
{
    public class CreateContactDTO
    {
        public string ContactMapLocation { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactOpenTimes { get; set; }
    }
}
