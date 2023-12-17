using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest;
using BookingService.Maui.Model.ApiRequest.User;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.ApiResponse.User;
using BookingService.Maui.Repository.Interface;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BookingService.Maui.Repository.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository()
        {

        }

        public async Task<ResultModel<List<UserAdministrationResponse>>> GetUserAdministration()
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("User/GetUserAdministration");
                if (response == null) return new ResultModel<List<UserAdministrationResponse>>(false, "Błąd połączenia z api",
                    new List<UserAdministrationResponse>());

                var responseData = await response.Content.ReadAsStringAsync();
                List<UserAdministrationResponse>? userAdministrationResponse = JsonConvert.DeserializeObject<List<UserAdministrationResponse>>(responseData);

                if (userAdministrationResponse == null)
                    return new ResultModel<List<UserAdministrationResponse>>(false, "Błąd wewnętrzny", new List<UserAdministrationResponse>());

                return new ResultModel<List<UserAdministrationResponse>>(true, userAdministrationResponse);
            }
            catch
            {
                return new ResultModel<List<UserAdministrationResponse>>(false, "Błąd wewnętrzny", new List<UserAdministrationResponse>());
            }
        }

        public async Task<ResultModel<UserResponse>> GetUserByIdAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("User/" + id.ToString());
                if (response == null) return new ResultModel<UserResponse>(false, "Błąd połączenia z api", new UserResponse());

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return new ResultModel<UserResponse>(false, "Niepoprawne id", new UserResponse());

                var responseData = await response.Content.ReadAsStringAsync();
                UserResponse? userResponse = JsonConvert.DeserializeObject<UserResponse>(responseData);

                if (userResponse == null)
                    return new ResultModel<UserResponse>(false, "Błąd wewnętrzny", new UserResponse());

                return new ResultModel<UserResponse>(true, "", userResponse);
            }
            catch
            {
                return new ResultModel<UserResponse>(false, "Błąd wewnętrzny", new UserResponse());
            }
        }

        public async Task<HttpResponseMessage?> LoginAsync(string login, string password)
        {
            LoginRequest loginModel = new()
            {
                Login = login,
                Password = password
            };
            try
            {
                HttpResponseMessage response = await HttpClient.PostAsJsonAsync("User/Login", loginModel);
                return response;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }
        }

        public async Task<ResultModel<BaseCommandResponse>> RegisterAsync(RegisteryRequest model)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.PostAsJsonAsync("User", model);
                if (response == null) return new ResultModel<BaseCommandResponse>(false, "Błąd połączenia z api", new BaseCommandResponse());

                var responseData = await response.Content.ReadAsStringAsync();
                BaseCommandResponse? registeryResponse = JsonConvert.DeserializeObject<BaseCommandResponse>(responseData);

                if (registeryResponse == null)
                    return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());

                if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
                    return new ResultModel<BaseCommandResponse>(false, registeryResponse.Message ?? string.Empty, registeryResponse);

                return new ResultModel<BaseCommandResponse>(true, "Pomyślnie zarejestrowano", registeryResponse);
            }
            catch
            {
                return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());
            }
        }

        public async Task<ResultModel<BaseCommandResponse>> UpdateUserRole(UpdateUserRoleRequest model)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.PutAsJsonAsync("User/UpdateUserRole", model);
                if (response == null) return new ResultModel<BaseCommandResponse>(false, "Błąd połączenia z api", new BaseCommandResponse());

                var responseData = await response.Content.ReadAsStringAsync();
                BaseCommandResponse? updateUserRoleResponse = JsonConvert.DeserializeObject<BaseCommandResponse>(responseData);

                if (updateUserRoleResponse == null)
                    return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());

                if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
                    return new ResultModel<BaseCommandResponse>(false, updateUserRoleResponse.Message ?? string.Empty, updateUserRoleResponse);

                if (!response.IsSuccessStatusCode)
                    return new ResultModel<BaseCommandResponse>(false, updateUserRoleResponse.Message ?? string.Empty, updateUserRoleResponse);

                return new ResultModel<BaseCommandResponse>(true, "Pomyślnie zaaktualizowano użytkownika", updateUserRoleResponse);
            }
            catch
            {
                return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());
            }
        }
    }
}
