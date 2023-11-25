using static BookingService.Maui.Model.Enums;
namespace BookingService.Maui.Model.Service
{
    public class ServiceLight
    {
        public int Id { get; set; }
        public string ComapnyName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ServiceType Type { get; set; }
    }
}
