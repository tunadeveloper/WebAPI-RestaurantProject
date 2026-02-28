using RestaurantProject.WebAPILayer.Entities.Common;

namespace RestaurantProject.WebAPILayer.Entities
{
    public class Message:BaseEntity
    {
        public string MessageNameSurname { get; set; }
        public string MessageEmail { get; set; }
        public string MessageSubject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageSendDate { get; set; }
        public bool MessageIsRead { get; set; }
    }
}
