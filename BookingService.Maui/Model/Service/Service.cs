using static BookingService.Maui.Model.Enums;
namespace BookingService.Maui.Model.Service
{
    public class Service
    {
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public ServiceType Type { get; set; }
        public int CompanyId { get; set; }
    }
}
