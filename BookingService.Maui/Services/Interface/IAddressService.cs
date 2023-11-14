using BookingService.Maui.Model;
using BookingService.Maui.Model.ViewModelResponse;

namespace BookingService.Maui.Services.Interface
{
    public interface IAddressService
    {
        Task<ResultModel<List<AddressInListResponse>>> GetAll();
    }
}
