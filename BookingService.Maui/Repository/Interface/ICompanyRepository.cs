using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiResponse.Company;

namespace BookingService.Maui.Repository.Interface
{
    public interface ICompanyRepository
    {
        public Task<ResultModel<CompanyLightResponse>> GetCompanyByUserId(int id);
    }
}
