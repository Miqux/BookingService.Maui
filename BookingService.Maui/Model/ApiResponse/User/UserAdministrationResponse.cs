﻿using static BookingService.Maui.Model.ApiResponse.ApiEnums;
namespace BookingService.Maui.Model.ApiResponse.User
{
    public class UserAdministrationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
