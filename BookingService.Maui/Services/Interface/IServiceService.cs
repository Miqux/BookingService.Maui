using BookingService.Maui.Model;
using BookingService.Maui.Model.Service;

namespace BookingService.Maui.Services.Interface
{
    public interface IServiceService
    {
        public Task<ResultModel<List<ServiceLight>>> GetServiceLight();
    }
}
