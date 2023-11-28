namespace BookingService.Maui.Model.ApiResponse.Address
{
    public class AddressResponse
    {
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Zipcode { get; set; } = string.Empty;
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
    }
}
