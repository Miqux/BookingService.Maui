using BookingService.Maui.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookingService.Maui.ViewModel
{
    public partial class BaseValidatorViewModel : ObservableValidator
    {
        [ObservableProperty]
        bool isBusy;

        public readonly IDialogService DialogService = Provider.ServiceProvider.GetService<IDialogService>();
        public readonly IAuthService AuthService = Provider.ServiceProvider.GetService<IAuthService>();

        public Tuple<bool, string> Validate()
        {
            ValidateAllProperties();

            bool result;
            string message = string.Empty;

            if (HasErrors)
            {
                var errors = GetErrors();
                result = false;
                message = errors != null ? errors.FirstOrDefault()?.ErrorMessage ?? string.Empty : string.Empty;
            }
            else
                result = true;

            return new Tuple<bool, string>(result, message);
        }
        public static void ClearNavigationStack()
        {
            var stack = Shell.Current.Navigation.NavigationStack.ToArray();
            for (int i = stack.Length - 1; i > 0; i--)
            {
                Shell.Current.Navigation.RemovePage(stack[i]);
            }
        }
    }
}
