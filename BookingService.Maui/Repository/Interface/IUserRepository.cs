using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest;
using BookingService.Maui.Model.ApiRequest.User;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.ApiResponse.User;

namespace BookingService.Maui.Repository.Interface
{
    public interface IUserRepository
    {
        public Task<HttpResponseMessage?> LoginAsync(string login, string password);
        public Task<ResultModel<UserResponse>> GetUserByIdAsync(int id);
        public Task<ResultModel<BaseCommandResponse>> RegisterAsync(RegisteryRequest model);
        public Task<ResultModel<List<UserAdministrationResponse>>> GetUserAdministration();
        public Task<ResultModel<BaseCommandResponse>> UpdateUserRole(UpdateUserRoleRequest model);
    }
}
