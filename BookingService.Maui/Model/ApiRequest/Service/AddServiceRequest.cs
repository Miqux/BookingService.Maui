using static BookingService.Maui.Model.ApiResponse.ApiEnums;
namespace BookingService.Maui.Model.ApiRequest.Service
{
    public class AddServiceRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public int CompanyId { get; set; }
        public ServiceType Type { get; set; }
    }
}
