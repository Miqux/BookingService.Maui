using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookingService.Maui.ViewModel.User
{
    public partial class RegisteryViewModel : ObservableValidator
    {
        [ObservableProperty]
        string? firstName;
        [ObservableProperty]
        string? lastName;
        [ObservableProperty]
        string? login;
        [ObservableProperty]
        string? password;
        [ObservableProperty]
        string? email;
        public RegisteryViewModel()
        {

        }
        [RelayCommand]
        public async Task RegisterButtonClick()
        {

        }
    }
}
