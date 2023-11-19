using AutoMapper;
using BookingService.Maui.Helpers;
using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.User;
using BookingService.Maui.Repository.Interface;
using BookingService.Maui.Services.Interface;
using Newtonsoft.Json;

namespace BookingService.Maui.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await userRepository.GetUserById(id);

            if (!user.Result)
                return null;

            return mapper.Map<User>(user.Value);
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
                await SecureStorage.Default.SetAsync("userId", JwtHelper.ExtractUserId(loginResponse.Token).ToString());

                return new ResultModel<bool>(true, "Pomyślnie zalogowano", true);
            }
            else
                return new ResultModel<bool>(false, "Nieznany błąd", false);
        }

        public async Task<bool> Logout()
        {
            return await Task.Run(() => SecureStorage.Default.Remove("jwtToken"));
        }
    }
}
