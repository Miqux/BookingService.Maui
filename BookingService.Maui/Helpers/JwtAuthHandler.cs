using System.Net.Http.Headers;

namespace BookingService.Maui.Helpers
{
    public class JwtAuthHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string jwtToken = await SecureStorage.Default.GetAsync("jwtToken");

            if (!string.IsNullOrEmpty(jwtToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
