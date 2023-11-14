using BookingService.Maui.Services.Interface;

namespace BookingService.Maui.Services.Services
{
    public class AuthService : IAuthService
    {
        public async Task<bool> IsLogged()
        {
            string jwtToken = await SecureStorage.Default.GetAsync("jwtToken");
            return !string.IsNullOrEmpty(jwtToken);
        }

        public async Task<string> Login(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
