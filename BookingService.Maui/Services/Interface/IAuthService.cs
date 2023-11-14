namespace BookingService.Maui.Services.Interface
{
    public interface IAuthService
    {
        public Task<bool> IsLogged();
        public Task<string> Login(string login, string password);
    }
}
