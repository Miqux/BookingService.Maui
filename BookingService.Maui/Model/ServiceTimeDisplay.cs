namespace BookingService.Maui.Model
{
    public class ServiceTimeDisplay
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string DisplayName
        {
            get
            {
                return this.StartTime.ToString(@"hh\:mm") + " : " + this.EndTime.ToString(@"hh\:mm");
            }
        }
    }
}
