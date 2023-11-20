namespace BookingService.Maui.Model
{
    public class ResultModel<T>
    {
        public bool Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Value { get; set; }
        public ResultModel(bool result, string message, T value)
        {
            Result = result;
            Message = message;
            Value = value;
        }
        public ResultModel(bool result, T value)
        {
            Result = result;
            Value = value;
        }
    }
}
