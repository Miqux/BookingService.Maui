using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest;
using BookingService.Maui.Model.ApiResponse;
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

        public async Task<ResultModel<UserResponse>> GetUserById(int id)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("User/" + id.ToString());
                if (response == null) return new ResultModel<UserResponse>(false, "Błąd połączenia z api", new UserResponse());

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return new ResultModel<UserResponse>(false, "Niepoprawne id", new UserResponse());

                var responseData = response.Content.ReadAsStringAsync().Result;
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

    }
}
