namespace RestaurantProject.WebAPILayer.DTOs.MessageDTOs
{
    public class UpdateMessageDTO
    {
        public int Id { get; set; }
        public string MessageNameSurname { get; set; }
        public string MessageEmail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageDetails { get; set; }
        public bool MessageIsRead { get; set; }
        public string? MessageStatus { get; set; }
    }
}
