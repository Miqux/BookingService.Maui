using BookingService.Maui.Services.Interface;
using BookingService.Maui.View.User;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Maui.ViewModel.User
{
    public partial class LoginViewModel : ObservableValidator
    {
        private readonly IDialogService dialogService;

        [Required(ErrorMessage = "Login jest wymagany!")]
        [MinLength(5, ErrorMessage = "Login powinien zawierać conajmniej 5!")]
        [MaxLength(20, ErrorMessage = "Login nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string? login;

        [Required(ErrorMessage = "Login jest wymagany!")]
        [MinLength(5, ErrorMessage = "Login powinien zawierać conajmniej 5!")]
        [MaxLength(20, ErrorMessage = "Login nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string? password;

        public LoginViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        [RelayCommand]
        public async Task LoginButtonClick()
        {
            var validation = Validate();
            if (!validation.Item1)
                await dialogService.ShowAlert("Niepoprawne dane", validation.Item2);
        }

        [RelayCommand]
        public async Task RegisteryButtonClick()
        {
            await Shell.Current.GoToAsync(nameof(RegisteryView));
        }
        private Tuple<bool, string> Validate()
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