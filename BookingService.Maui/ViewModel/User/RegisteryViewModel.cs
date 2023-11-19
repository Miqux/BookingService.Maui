using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Maui.ViewModel.User
{
    public partial class RegisteryViewModel : BaseValidatorViewModel
    {
        #region ValidationProperty
        [Required(ErrorMessage = "Imię jest wymagany!")]
        [MinLength(3, ErrorMessage = "Imię powinno zawierać conajmniej 3 znaki!")]
        [MaxLength(20, ErrorMessage = "Imię nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string? firstName;

        [Required(ErrorMessage = "Nazwisko jest wymagany!")]
        [MinLength(3, ErrorMessage = "Nazwisko powinno zawierać conajmniej 3 znaki!")]
        [MaxLength(20, ErrorMessage = "Nazwisko nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string? lastName;

        [Required(ErrorMessage = "Login jest wymagany!")]
        [MinLength(5, ErrorMessage = "Login powinien zawierać conajmniej 5 znaków!")]
        [MaxLength(20, ErrorMessage = "Login nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string? login;

        [Required(ErrorMessage = "Hasło jest wymagany!")]
        [MinLength(5, ErrorMessage = "Hasło powinno zawierać conajmniej 5 znaki!")]
        [MaxLength(20, ErrorMessage = "Hasło nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string? password;

        [Required(ErrorMessage = "Email jest wymagany!")]
        [EmailAddress(ErrorMessage = "Email nie spełnia wymagań")]
        [ObservableProperty]
        string? email;
        #endregion

        public RegisteryViewModel()
        {

        }

        [RelayCommand]
        public async Task RegisterButtonClick()
        {
            var validation = Validate();
            if (!validation.Item1)
                await DialogService.ShowAlert("Niepoprawne dane", validation.Item2);
        }
    }
}
