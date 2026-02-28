namespace RestaurantProject.WebAPILayer.DTOs.MessageDTOs
{
    public class CreateMessageDTO
    {
        public string MessageNameSurname { get; set; }
        public string MessageEmail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageDetails { get; set; }
    }
}
