using BookingService.Maui.View.User;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Maui.ViewModel.User
{
    public partial class LoginViewModel : BaseValidatorViewModel
    {

        #region ValidationProperty
        [Required(ErrorMessage = "Login jest wymagany!")]
        [MinLength(5, ErrorMessage = "Login powinien zawierać conajmniej 5!")]
        [MaxLength(20, ErrorMessage = "Login nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string login = string.Empty;

        [Required(ErrorMessage = "Hasło jest wymagany!")]
        [MinLength(5, ErrorMessage = "Hasło powinno zawierać conajmniej 5!")]
        [MaxLength(20, ErrorMessage = "Hasło nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string password = string.Empty;

        #endregion

        [RelayCommand]
        public async Task LoginButtonClick()
        {
            try
            {
                IsBusy = true;
                var validation = Validate();
                if (!validation.Item1)
                {
                    await DialogService.ShowAlert("Niepoprawne dane", validation.Item2);
                    return;
                }

                var loginResult = await AuthService.Login(Login, Password);

                if (!loginResult.Result)
                {
                    await DialogService.ShowAlert("Błąd", loginResult.Message);
                    return;
                }
                await DialogService.ShowAlert("Zalogowano", "Pomyślnie zalogowano");
                await Shell.Current.GoToAsync(nameof(UserView));
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task RegisteryButtonClick()
        {
            await Shell.Current.GoToAsync(nameof(RegisteryView));
        }
    }
}