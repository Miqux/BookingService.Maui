using BookingService.Maui.Model.User;
using BookingService.Maui.Services.Interface;
using BookingService.Maui.View.User;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Maui.ViewModel.User
{
    public partial class RegisteryViewModel : BaseValidatorViewModel
    {
        private readonly IAuthService authService;

        #region ValidationProperty
        [Required(ErrorMessage = "Imię jest wymagany!")]
        [MinLength(3, ErrorMessage = "Imię powinno zawierać conajmniej 3 znaki!")]
        [MaxLength(20, ErrorMessage = "Imię nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string firstName = string.Empty;

        [Required(ErrorMessage = "Nazwisko jest wymagany!")]
        [MinLength(3, ErrorMessage = "Nazwisko powinno zawierać conajmniej 3 znaki!")]
        [MaxLength(20, ErrorMessage = "Nazwisko nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string lastName = string.Empty;

        [Required(ErrorMessage = "Login jest wymagany!")]
        [MinLength(5, ErrorMessage = "Login powinien zawierać conajmniej 5 znaków!")]
        [MaxLength(20, ErrorMessage = "Login nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string login = string.Empty;

        [Required(ErrorMessage = "Hasło jest wymagany!")]
        [MinLength(5, ErrorMessage = "Hasło powinno zawierać conajmniej 5 znaki!")]
        [MaxLength(20, ErrorMessage = "Hasło nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string password = string.Empty;

        [Required(ErrorMessage = "Email jest wymagany!")]
        [EmailAddress(ErrorMessage = "Email nie spełnia wymagań")]
        [ObservableProperty]
        string email = string.Empty;
        #endregion

        public RegisteryViewModel(IAuthService authService)
        {
            this.authService = authService;
        }

        [RelayCommand]
        public async Task RegisterButtonClick()
        {
            var validation = Validate();
            if (!validation.Item1)
            {
                await DialogService.ShowAlert("Niepoprawne dane", validation.Item2);
                return;
            }

            var registerModel = new RegisterUser()
            {
                Name = FirstName,
                LastName = LastName,
                Login = Login,
                Password = Password,
                Email = Email,
                Role = Model.Enums.UserRole.User
            };

            var registrationResult = await AuthService.Register(registerModel);

            if (!registrationResult.Result)
            {
                await DialogService.ShowAlert("Niepoprawne dane", registrationResult.Message);
                return;
            }

            await DialogService.ShowAlert("Powodzenie", "Pomyślnie zarejestrowano");
            await Shell.Current.GoToAsync(nameof(UserView));
            return;
        }
    }
}
