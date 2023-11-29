using static BookingService.Maui.Model.ApiResponse.ApiEnums;

namespace BookingService.Maui.Model.ApiResponse.Service
{
    public class CompanyServiceResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public ServiceType Type { get; set; }
    }
}
