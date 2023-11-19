using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Repository.Interface;
using BookingService.Maui.Services.Interface;
using Newtonsoft.Json;

namespace BookingService.Maui.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public async Task<ResultModel<List<AddressInListResponse>>> GetAll()
        {
            var response = await addressRepository.GetAll();
            if (response == null)
                return new ResultModel<List<AddressInListResponse>>(false, "Błąd połączenia z api", new List<AddressInListResponse>());

            List<AddressInListResponse>? address = new();

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;

                if (responseData == null)
                    return new ResultModel<List<AddressInListResponse>>(false, "Błąd wewnętrzny", address);

                address = JsonConvert.DeserializeObject<List<AddressInListResponse>>(responseData);

                if (address == null)
                    return new ResultModel<List<AddressInListResponse>>(false, "Błąd wewnętrzny", new List<AddressInListResponse>());

                return new ResultModel<List<AddressInListResponse>>(true, "Pomyślnie zalogowano", address);
            }
            else
                return new ResultModel<List<AddressInListResponse>>(false, response.ReasonPhrase != null ? response.ReasonPhrase.ToString() : "", address);

        }
    }
}
