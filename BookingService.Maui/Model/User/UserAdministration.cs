using static BookingService.Maui.Model.Enums;
namespace BookingService.Maui.Model.User
{
    public class UserAdministration
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
