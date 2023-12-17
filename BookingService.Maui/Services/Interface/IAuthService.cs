using BookingService.Maui.Model;
using BookingService.Maui.Model.User;

namespace BookingService.Maui.Services.Interface
{
    public interface IAuthService
    {
        public Task<bool> IsLogged();
        public Task<bool> IsCompanyBoss();
        public Task<ResultModel<bool>> Login(string login, string password);
        public Task<User?> GetUserById(int id);
        public void Logout();
        public Task<ResultModel<bool>> Register(RegisterUser model);
        public Task<ResultModel<List<UserAdministration>>> GetUserAdministration();
        public Task<ResultModel<bool>> UpdateUserRole(UpdateUserRole model);
    }
}
