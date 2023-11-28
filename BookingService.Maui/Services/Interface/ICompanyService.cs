using BookingService.Maui.Model;
using BookingService.Maui.Model.Company;

namespace BookingService.Maui.Services.Interface
{
    public interface ICompanyService
    {
        Task<ResultModel<CompanyLight?>> GetByUserId(int id);
    }
}
