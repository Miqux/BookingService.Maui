using static BookingService.Maui.Model.ApiResponse.ApiEnums;

namespace BookingService.Maui.Model.ApiResponse
{
    public class ServicesLightResponse
    {
        public int Id { get; set; }
        public string ComapnyName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ServiceType Type { get; set; }
    }
}
