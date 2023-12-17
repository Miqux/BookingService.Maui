using AutoMapper;
using BookingService.Maui.Helpers;
using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest;
using BookingService.Maui.Model.ApiRequest.User;
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
            var user = await userRepository.GetUserByIdAsync(id);

            if (!user.Result)
                return null;

            return mapper.Map<User>(user.Value);
        }
        public async Task<bool> IsLogged()
        {
            string jwtToken = await SecureStorage.Default.GetAsync("jwtToken");
            return !string.IsNullOrEmpty(jwtToken);
        }
        public async Task<bool> IsCompanyBoss()
        {
            string jwtToken = await SecureStorage.Default.GetAsync("actoreRole");
            return !string.IsNullOrEmpty(jwtToken) && jwtToken.Equals("CompanyBoss");
        }
        public async Task<ResultModel<bool>> Login(string login, string password)
        {
            var response = await userRepository.LoginAsync(login, password);
            if (response == null) return new ResultModel<bool>(false, "Błąd połączenia z api", false);
            if (response.IsSuccessStatusCode)
            {
                var loginResponseData = response.Content.ReadAsStringAsync().Result;
                LoginResponse? loginResponse = JsonConvert.DeserializeObject<LoginResponse>(loginResponseData);

                if (loginResponse is null)
                    return new ResultModel<bool>(false, "Błąd wewnętrzny", false);

                if (!loginResponse.Success)
                    return new ResultModel<bool>(false, "Nieprawidłowa nazwa użytkownika lub hasło", false);

                await SecureStorage.Default.SetAsync("jwtToken", loginResponse.Token);
                await SecureStorage.Default.SetAsync("userId", JwtHelper.ExtractUserId(loginResponse.Token).ToString());
                await SecureStorage.Default.SetAsync("actoreRole", JwtHelper.ExtractUserRole(loginResponse.Token));

                return new ResultModel<bool>(true, "Pomyślnie zalogowano", true);
            }
            else
                return new ResultModel<bool>(false, "Nieznany błąd", false);
        }
        public void Logout()
        {
            SecureStorage.Default.RemoveAll();
        }
        public async Task<ResultModel<bool>> Register(RegisterUser model)
        {
            var registerModel = mapper.Map<RegisteryRequest>(model);
            var registerResult = await userRepository.RegisterAsync(registerModel);

            if (!registerResult.Result)
                return new ResultModel<bool>(false, registerResult.Message, false);

            return new ResultModel<bool>(true, true);
        }
        public async Task<ResultModel<List<UserAdministration>>> GetUserAdministration()
        {
            var users = await userRepository.GetUserAdministration();

            if (!users.Result || users.Value is null)
                return new ResultModel<List<UserAdministration>>(false, users.Message, new List<UserAdministration>());

            return new ResultModel<List<UserAdministration>>(true, mapper.Map<List<UserAdministration>>(users.Value));
        }
        public async Task<ResultModel<bool>> UpdateUserRole(UpdateUserRole model)
        {
            var updateUserModel = mapper.Map<UpdateUserRoleRequest>(model);
            var updateUserResponse = await userRepository.UpdateUserRole(updateUserModel);

            if (!updateUserResponse.Result)
                return new ResultModel<bool>(false, updateUserResponse.Message, false);

            return new ResultModel<bool>(true, true);
        }
    }
}
