namespace BookingService.Maui.Model.ApiResponse
{
    public class BaseResponse
    {
        public ResponseStatus Status { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<string> ValidationErrors { get; set; } = new List<string>();
        public enum ResponseStatus
        {
            Success = 0,
            NotFound = 1,
            BadQuery = 2,
            ValidationError = 3
        }
    }
}
