namespace BookingService.Maui.Repository.Interface
{
    public interface IAddressRepository
    {
        public Task<HttpResponseMessage?> GetAll();
    }
}
