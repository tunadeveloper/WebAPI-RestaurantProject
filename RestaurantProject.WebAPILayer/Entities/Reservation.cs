using RestaurantProject.WebAPILayer.Entities.Common;

namespace RestaurantProject.WebAPILayer.Entities
{
    public class Reservation:BaseEntity
    {
        public string ReservationNameSurname { get; set; }
        public string ReservationEmail { get; set; }
        public string ReservationPhoneNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ReservationCountOfPeople { get; set; }
        public string ReservationMessage { get; set; }
        public string ReservationStatus { get; set; }
    }
}
