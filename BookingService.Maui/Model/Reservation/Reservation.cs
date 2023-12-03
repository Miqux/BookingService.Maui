namespace BookingService.Maui.Model.Reservation
{
    public class Reservation
    {
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime StartDateAndTime { get; set; }
        public DateTime EndDateAndTime { get; set; }
    }
}
