﻿using static BookingService.Maui.Model.Enums;

namespace BookingService.Maui.Model.ApiResponse.Service
{
    public class ServiceDetailsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int DurationInMinutes { get; set; }
        public ServiceType Type { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyAddressCity { get; set; } = string.Empty;
        public string CompanyAddressStreet { get; set; } = string.Empty;
        public string CompanyAddressZipcode { get; set; } = string.Empty;
        public int CompanyAddressHouseNumber { get; set; }
        public int CompanyAddressApartmentNumber { get; set; }
    }
}
