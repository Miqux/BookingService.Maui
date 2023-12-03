using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Service;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.ApiResponse.Service;
using BookingService.Maui.Repository.Interface;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BookingService.Maui.Repository.Repository
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public async Task<ResultModel<List<CompanyServiceResponse>>> GetCompanyServices(int companyId)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("Service/GetCompanyServices/" + companyId.ToString());
                if (response == null) return new ResultModel<List<CompanyServiceResponse>>(false, "Błąd połączenia z api",
                    new List<CompanyServiceResponse>());

                var responseData = await response.Content.ReadAsStringAsync();
                List<CompanyServiceResponse>? servicesResponse = JsonConvert.DeserializeObject<List<CompanyServiceResponse>>(responseData);

                if (servicesResponse == null)
                    return new ResultModel<List<CompanyServiceResponse>>(false, "Błąd wewnętrzny", new List<CompanyServiceResponse>());

                return new ResultModel<List<CompanyServiceResponse>>(true, servicesResponse);
            }
            catch
            {
                return new ResultModel<List<CompanyServiceResponse>>(false, "Błąd wewnętrzny", new List<CompanyServiceResponse>());
            }
        }

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
            catch (Exception ex)
            {
                return new ResultModel<List<ServicesLightResponse>>(false, "Błąd wewnętrzny", new List<ServicesLightResponse>());
            }
        }

        public async Task<ResultModel<BaseCommandResponse>> AddService(AddServiceRequest model)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Service", model);
                if (response == null) return new ResultModel<BaseCommandResponse>(false, "Błąd połączenia z api", new BaseCommandResponse());

                var responseData = await response.Content.ReadAsStringAsync();
                BaseCommandResponse? registeryResponse = JsonConvert.DeserializeObject<BaseCommandResponse>(responseData);

                if (registeryResponse == null)
                    return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());

                if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
                    return new ResultModel<BaseCommandResponse>(false, registeryResponse.Message ?? string.Empty, registeryResponse);

                return new ResultModel<BaseCommandResponse>(true, "Pomyślnie dodano usługę", registeryResponse);
            }
            catch
            {
                return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());
            }
        }

        public async Task<ResultModel<BaseResponse>> DeleteService(int id)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.DeleteAsync("Service/" + id.ToString());
                if (response == null) return new ResultModel<BaseResponse>(false, "Błąd połączenia z api", new BaseCommandResponse());

                var responseData = await response.Content.ReadAsStringAsync();
                BaseResponse? registeryResponse = JsonConvert.DeserializeObject<BaseResponse>(responseData);

                if (registeryResponse == null)
                    return new ResultModel<BaseResponse>(false, "Błąd wewnętrzny", new BaseResponse());

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return new ResultModel<BaseResponse>(false, registeryResponse.Message ?? string.Empty, registeryResponse);

                return new ResultModel<BaseResponse>(true, "Pomyślnie usunięto usługę", registeryResponse);
            }
            catch
            {
                return new ResultModel<BaseResponse>(false, "Błąd wewnętrzny", new BaseResponse());
            }
        }

        public async Task<ResultModel<ServiceDetailsResponse>> GetServicesDetails(int id)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("Service/GetServiceDetails/" + id.ToString());
                if (response == null) return new ResultModel<ServiceDetailsResponse>(false, "Błąd połączenia z api",
                    new ServiceDetailsResponse());

                var responseData = await response.Content.ReadAsStringAsync();
                ServiceDetailsResponse? servicesResponse = JsonConvert.DeserializeObject<ServiceDetailsResponse>(responseData);

                if (servicesResponse == null)
                    return new ResultModel<ServiceDetailsResponse>(false, "Błąd wewnętrzny", new ServiceDetailsResponse());

                return new ResultModel<ServiceDetailsResponse>(true, servicesResponse);
            }
            catch
            {
                return new ResultModel<ServiceDetailsResponse>(false, "Błąd wewnętrzny", new ServiceDetailsResponse());
            }
        }

        public async Task<ResultModel<List<PossibleServiceHourResponse>>> GetPossibleServiceHours(int id, DateOnly date)
        {
            try
            {
                var temp = date.ToString();
                HttpResponseMessage response = await HttpClient.GetAsync(string.Format("Service/GetPossibleServiceHour/" + id.ToString() + "/" + date.ToString()));
                if (response == null) return new ResultModel<List<PossibleServiceHourResponse>>(false, "Błąd połączenia z api",
                    new List<PossibleServiceHourResponse>());

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return new ResultModel<List<PossibleServiceHourResponse>>(false, "Brak wolnych godzin",
                    new List<PossibleServiceHourResponse>());

                if (!response.IsSuccessStatusCode)
                    return new ResultModel<List<PossibleServiceHourResponse>>(false, "Nie udało się pobrać", new List<PossibleServiceHourResponse>());

                var responseData = await response.Content.ReadAsStringAsync();
                List<PossibleServiceHourResponse>? servicesResponse = JsonConvert.DeserializeObject<List<PossibleServiceHourResponse>>(responseData);

                if (servicesResponse == null)
                    return new ResultModel<List<PossibleServiceHourResponse>>(false, "Błąd wewnętrzny", new List<PossibleServiceHourResponse>());

                return new ResultModel<List<PossibleServiceHourResponse>>(true, servicesResponse);
            }
            catch (Exception ex)
            {
                return new ResultModel<List<PossibleServiceHourResponse>>(false, "Błąd wewnętrzny", new List<PossibleServiceHourResponse>());
            }
        }
    }
}
