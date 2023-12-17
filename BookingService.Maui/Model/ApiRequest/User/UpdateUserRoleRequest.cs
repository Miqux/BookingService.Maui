using static BookingService.Maui.Model.ApiResponse.ApiEnums;

namespace BookingService.Maui.Model.ApiRequest.User
{
    public class UpdateUserRoleRequest
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
    }
}
