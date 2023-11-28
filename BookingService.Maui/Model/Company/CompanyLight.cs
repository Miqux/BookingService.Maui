namespace BookingService.Maui.Model.Company
{
    public class CompanyLight
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public int CalendarId { get; set; }
    }
}
