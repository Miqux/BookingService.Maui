namespace BookingService.Maui.Repository.Interface
{
    public interface IUserRepository
    {
        public Task<HttpResponseMessage?> LoginAsync(string login, string password);
    }
}
