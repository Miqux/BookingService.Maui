using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest;
using BookingService.Maui.Model.ApiResponse;

namespace BookingService.Maui.Repository.Interface
{
    public interface IUserRepository
    {
        public Task<HttpResponseMessage?> LoginAsync(string login, string password);
        public Task<ResultModel<UserResponse>> GetUserByIdAsync(int id);
        public Task<ResultModel<BaseCommandResponse>> RegisterAsync(RegisteryRequest model);
    }
}
