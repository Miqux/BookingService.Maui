using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiResponse;

namespace BookingService.Maui.Services.Interface
{
    public interface IAddressService
    {
        Task<ResultModel<List<AddressInListResponse>>> GetAll();
    }
}
