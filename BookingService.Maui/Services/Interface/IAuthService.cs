using BookingService.Maui.Model;

namespace BookingService.Maui.Services.Interface
{
    public interface IAuthService
    {
        public Task<bool> IsLogged();
        public Task<ResultModel<bool>> Login(string login, string password);
    }
}
