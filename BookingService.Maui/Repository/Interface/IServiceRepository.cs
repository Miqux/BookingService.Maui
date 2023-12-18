using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Service;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.ApiResponse.Service;

namespace BookingService.Maui.Repository.Interface
{
    public interface IServiceRepository
    {
        public Task<ResultModel<List<ServicesLightResponse>>> GetServicesLight(int? serviceType, string? city);
        public Task<ResultModel<ServiceDetailsResponse>> GetServicesDetails(int id);
        public Task<ResultModel<List<CompanyServiceResponse>>> GetCompanyServices(int companyId);
        public Task<ResultModel<BaseCommandResponse>> AddService(AddServiceRequest model);
        public Task<ResultModel<BaseResponse>> DeleteService(int id);
        public Task<ResultModel<List<PossibleServiceHourResponse>>> GetPossibleServiceHours(int id, DateOnly date);
    }
}
