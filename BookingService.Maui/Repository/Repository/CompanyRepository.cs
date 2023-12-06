using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Company;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.ApiResponse.Company;
using BookingService.Maui.Repository.Interface;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BookingService.Maui.Repository.Repository
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public async Task<ResultModel<CompanyLightResponse>> GetCompanyByUserId(int id)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("Company/GetByUserId/" + id.ToString());
                if (response == null) return new ResultModel<CompanyLightResponse>(false, "Błąd połączenia z api",
                    new CompanyLightResponse());

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return new ResultModel<CompanyLightResponse>(false, "Brak firmy", new CompanyLightResponse());

                var responseData = await response.Content.ReadAsStringAsync();
                CompanyLightResponse? companyResponse = JsonConvert.DeserializeObject<CompanyLightResponse>(responseData);

                if (companyResponse == null)
                    return new ResultModel<CompanyLightResponse>(false, "Błąd wewnętrzny", new CompanyLightResponse());

                return new ResultModel<CompanyLightResponse>(true, companyResponse);
            }
            catch
            {
                return new ResultModel<CompanyLightResponse>(false, "Błąd wewnętrzny", new CompanyLightResponse());
            }
        }

        public async Task<ResultModel<BaseCommandResponse>> UpdateCompany(UpdateCompanyRequest model)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.PutAsJsonAsync("Company", model);
                if (response == null) return new ResultModel<BaseCommandResponse>(false, "Błąd połączenia z api", new BaseCommandResponse());

                var responseData = await response.Content.ReadAsStringAsync();
                BaseCommandResponse? registeryResponse = JsonConvert.DeserializeObject<BaseCommandResponse>(responseData);

                if (registeryResponse == null)
                    return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());

                if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
                    return new ResultModel<BaseCommandResponse>(false, registeryResponse.Message ?? string.Empty, registeryResponse);

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return new ResultModel<BaseCommandResponse>(false, registeryResponse.Message ?? string.Empty, registeryResponse);

                return new ResultModel<BaseCommandResponse>(true, "Pomyślnie dodano usługę", registeryResponse);
            }
            catch
            {
                return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());
            }
        }
    }
}
