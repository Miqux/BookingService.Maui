namespace BookingService.Maui.Repository
{
    public class BaseRepository
    {
        public HttpClient HttpClient;
        public BaseRepository()
        {
            HttpClient = new HttpClient();
        }
    }
}
