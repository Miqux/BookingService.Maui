using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Company;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.ApiResponse.Company;

namespace BookingService.Maui.Repository.Interface
{
    public interface ICompanyRepository
    {
        public Task<ResultModel<CompanyLightResponse>> GetCompanyByUserId(int id);
        public Task<ResultModel<BaseCommandResponse>> UpdateCompany(UpdateCompanyRequest model);
    }
}
