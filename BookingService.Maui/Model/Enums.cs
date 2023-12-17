using System.ComponentModel;

namespace BookingService.Maui.Model
{
    public class Enums
    {
        public enum UserRole
        {
            CompanyBoss = 1,
            User = 2,
            Admin = 3
        }
        public enum ServiceType
        {
            [Description("Strzyżenie")]
            Haircut = 1,
            [Description("Trymerowanie brody")]
            BeardTrimming = 2,
            [Description("Combo")]
            Combo = 3
        }
    }
}
