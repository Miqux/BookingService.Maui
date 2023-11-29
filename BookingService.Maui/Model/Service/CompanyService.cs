using static BookingService.Maui.Model.Enums;
namespace BookingService.Maui.Model.Service
{
    public class CompanyService
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public ServiceType Type { get; set; }
    }
}
