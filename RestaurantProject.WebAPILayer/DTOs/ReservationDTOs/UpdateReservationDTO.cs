namespace RestaurantProject.WebAPILayer.DTOs.ReservationDTOs
{
    public class UpdateReservationDTO
    {
        public int Id { get; set; }
        public string ReservationNameSurname { get; set; }
        public string ReservationEmail { get; set; }
        public string ReservationPhoneNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ReservationCountOfPeople { get; set; }
        public string ReservationMessage { get; set; }
        public string ReservationStatus { get; set; }
    }
}
