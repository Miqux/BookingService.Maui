using BookingService.Maui.Repository.Interface;

namespace BookingService.Maui.Repository.Repository
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public async Task<HttpResponseMessage?> GetAll()
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("Address");
                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}
