using BookingService.Maui.Repository.Interface;

namespace BookingService.Maui.Repository.Repository
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public async Task<HttpResponseMessage?> GetAll()
        {
            string apiUrl = HttpClient.BaseAddress + "Address";
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync(apiUrl);
                return response;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }
        }
    }
}
