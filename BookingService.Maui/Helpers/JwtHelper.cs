using System.IdentityModel.Tokens.Jwt;

namespace BookingService.Maui.Helpers
{
    public static class JwtHelper
    {
        public static int ExtractUserId(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken != null && jsonToken.Subject != null && int.TryParse(jsonToken.Subject, out var userId))
                return userId;

            return -1;
        }
    }
}
