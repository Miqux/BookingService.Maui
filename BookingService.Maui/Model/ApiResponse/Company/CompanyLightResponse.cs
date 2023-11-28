namespace BookingService.Maui.Model.ApiResponse.Company
{
    public class CompanyLightResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public int CalendarId { get; set; }
    }
}
