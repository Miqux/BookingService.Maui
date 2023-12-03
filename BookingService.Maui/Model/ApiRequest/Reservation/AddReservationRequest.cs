namespace BookingService.Maui.Model.ApiRequest.Reservation
{
    public class AddReservationRequest
    {
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime StartDateAndTime { get; set; }
        public DateTime EndDateAndTime { get; set; }
    }
}
