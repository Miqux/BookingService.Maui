using BookingService.Maui.Model.ViewModelRequest;
using BookingService.Maui.Repository.Interface;
using System.Net.Http.Json;

namespace BookingService.Maui.Repository.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository()
        {

        }
        public async Task<HttpResponseMessage?> LoginAsync(string login, string password)
        {
            LoginRequest loginModel = new()
            {
                Login = login,
                Password = password
            };
            string apiUrl = HttpClient.BaseAddress + "User/Login";
            try
            {
                HttpResponseMessage response = await HttpClient.PostAsJsonAsync(apiUrl, loginModel);
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
