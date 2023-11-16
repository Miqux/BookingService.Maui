using BookingService.Maui.Model;
using BookingService.Maui.Model.ViewModelResponse;
using BookingService.Maui.Repository.Interface;
using BookingService.Maui.Services.Interface;
using Newtonsoft.Json;

namespace BookingService.Maui.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;

        public AuthService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<bool> IsLogged()
        {
            string jwtToken = await SecureStorage.Default.GetAsync("jwtToken");
            return !string.IsNullOrEmpty(jwtToken);
        }

        public async Task<ResultModel<bool>> Login(string login, string password)
        {
            var response = await userRepository.LoginAsync(login, password);
            if (response == null) return new ResultModel<bool>(false, "Błąd połączenia z api", false);
            if (response.IsSuccessStatusCode)
            {
                var loginResponseData = response.Content.ReadAsStringAsync().Result;
                LoginResponse? loginResponse = JsonConvert.DeserializeObject<LoginResponse>(loginResponseData);

                if (loginResponse == null)
                    return new ResultModel<bool>(false, "Błąd wewnętrzny", false);

                if (!loginResponse.Success)
                    return new ResultModel<bool>(false, "Nieprawidłowa nazwa użytkownika lub hasło", false);

                await SecureStorage.Default.SetAsync("jwtToken", loginResponse.Token);
                return new ResultModel<bool>(true, "Pomyślnie zalogowano", true);
            }
            else
                return new ResultModel<bool>(false, response.ReasonPhrase != null ? response.ReasonPhrase.ToString() : "", false);
        }

        public async Task<bool> Logout()
        {
            return await Task.Run(() => SecureStorage.Default.Remove("jwtToken"));
        }
    }
}
