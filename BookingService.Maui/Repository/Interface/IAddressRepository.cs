using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiResponse.Address;

namespace BookingService.Maui.Repository.Interface
{
    public interface IAddressRepository
    {
        public Task<HttpResponseMessage?> GetAll();
        public Task<ResultModel<AddressResponse>> GetById(int id);
    }
}
