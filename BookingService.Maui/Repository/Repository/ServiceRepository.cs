using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Repository.Interface;
using Newtonsoft.Json;

namespace BookingService.Maui.Repository.Repository
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public async Task<ResultModel<List<ServicesLightResponse>>> GetServicesLight()
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("Service/GetLightModels");
                if (response == null) return new ResultModel<List<ServicesLightResponse>>(false, "Błąd połączenia z api",
                    new List<ServicesLightResponse>());

                var responseData = await response.Content.ReadAsStringAsync();
                List<ServicesLightResponse>? servicesResponse = JsonConvert.DeserializeObject<List<ServicesLightResponse>>(responseData);

                if (servicesResponse == null)
                    return new ResultModel<List<ServicesLightResponse>>(false, "Błąd wewnętrzny", new List<ServicesLightResponse>());

                return new ResultModel<List<ServicesLightResponse>>(true, servicesResponse);
            }
            catch
            {
                return new ResultModel<List<ServicesLightResponse>>(false, "Błąd wewnętrzny", new List<ServicesLightResponse>());
            }
        }
    }
}
