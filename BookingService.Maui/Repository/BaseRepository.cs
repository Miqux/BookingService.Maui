namespace BookingService.Maui.Repository
{
    public class BaseRepository
    {
        public HttpClient HttpClient;
        private readonly IHttpClientFactory httpClientFactory = Provider.ServiceProvider.GetService<IHttpClientFactory>();

        public BaseRepository()
        {
            HttpClient = httpClientFactory.CreateClient("BookingServiceApi");
        }
    }
}
