using BookingService.Maui.Model;

namespace BookingService.Maui.Services.Interface
{
    public interface IDialogService
    {
        Task<string> ShowOptionsDialog(string title, IEnumerable<string> options);
        Task<ResultModel<int>> ShowInputDialogInt(string title, string message, string defaultValue = "");
        Task<bool> ShowYesOrNoDialog(string title, string text);
        Task ShowAlert(string title, string message, string cancel = "OK");
    }
}
