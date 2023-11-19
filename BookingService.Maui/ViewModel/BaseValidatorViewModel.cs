using BookingService.Maui.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookingService.Maui.ViewModel
{
    public class BaseValidatorViewModel : ObservableValidator
    {
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
    }
}
