using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiResponse;

namespace BookingService.Maui.Repository.Interface
{
    public interface IServiceRepository
    {
        public Task<ResultModel<List<ServicesLightResponse>>> GetServicesLight();
    }
}
