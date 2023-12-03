using BookingService.Maui.Model;
using BookingService.Maui.Model.Service;

namespace BookingService.Maui.Services.Interface
{
    public interface IServiceService
    {
        public Task<ResultModel<List<ServiceLight>>> GetServiceLight();
        public Task<ResultModel<List<CompanyService>>> GetCompanyServices(int comapnyId);
        public Task<ResultModel<int?>> AddService(Service model);
        public Task<ResultModel<bool>> DeleteService(int id);
        public Task<ResultModel<ServiceDetails>> GetServiceDetalis(int id);
        public Task<ResultModel<List<ServiceTime>>> GetPossibleServiceHours(int id, DateOnly date);
    }
}
