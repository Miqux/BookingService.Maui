using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiResponse.Company;
using BookingService.Maui.Repository.Interface;
using Newtonsoft.Json;

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
    }
}
