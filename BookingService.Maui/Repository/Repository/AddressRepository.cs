using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiResponse.Address;
using BookingService.Maui.Repository.Interface;
using Newtonsoft.Json;

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

        public async Task<ResultModel<AddressResponse>> GetById(int id)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("Address/" + id.ToString());
                if (response == null) return new ResultModel<AddressResponse>(false, "Błąd połączenia z api",
                    new AddressResponse());

                var responseData = await response.Content.ReadAsStringAsync();
                AddressResponse? addressResponse = JsonConvert.DeserializeObject<AddressResponse>(responseData);

                if (addressResponse == null)
                    return new ResultModel<AddressResponse>(false, "Błąd wewnętrzny", new AddressResponse());

                return new ResultModel<AddressResponse>(true, addressResponse);
            }
            catch
            {
                return new ResultModel<AddressResponse>(false, "Błąd wewnętrzny", new AddressResponse());
            }
        }
    }
}
