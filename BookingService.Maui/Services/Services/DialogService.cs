using BookingService.Maui.Model;
using BookingService.Maui.Services.Interface;

namespace BookingService.Maui.Services.Services
{
    public class DialogService : IDialogService
    {
        public async Task<string> ShowOptionsDialog(string title, IEnumerable<string> options)
        {
            var result = await Application.Current.MainPage.DisplayActionSheet(title, "Zamknij", null, options.ToArray());
            return result;
        }
        public async Task<bool> ShowYesOrNoDialog(string title, string text)
        {
            bool result = await Application.Current.MainPage.DisplayAlert(title, text, "Tak", "Nie");
            return result;
        }
        public async Task<ResultModel<int>> ShowInputDialogInt(string title, string message, string defaultValue = "")
        {
            var propmtResult = await Application.Current.MainPage.DisplayPromptAsync(title, message, initialValue: defaultValue,
                keyboard: Keyboard.Numeric);

            if (propmtResult == null)
                return new ResultModel<int>(false, "", 0);

            _ = Int32.TryParse(propmtResult, out int value);
            return new ResultModel<int>(true, "", value);
        }
        public async Task ShowAlert(string title, string message, string cancel = "OK")
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}
