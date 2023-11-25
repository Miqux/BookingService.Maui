using BookingService.Maui.View.User;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookingService.Maui.ViewModel.User
{
    public partial class UserViewModel : BaseViewModel
    {
        #region ObservableProperty

        [ObservableProperty]
        bool isLogged;
        [ObservableProperty]
        string name = string.Empty;
        [ObservableProperty]
        string login = string.Empty;
        [ObservableProperty]
        string lastName = string.Empty;
        [ObservableProperty]
        string email = string.Empty;

        [ObservableProperty]
        bool isCompanyBoss;
        [ObservableProperty]
        string companyName = string.Empty;
        [ObservableProperty]
        string city = string.Empty;
        [ObservableProperty]
        string street = string.Empty;
        [ObservableProperty]
        string zipcode = string.Empty;
        [ObservableProperty]
        int houseNumber;
        [ObservableProperty]
        int apartmentNumber;

        #endregion

        [RelayCommand]
        private async Task LoginButtonClick()
        {
            await Shell.Current.GoToAsync(nameof(LoginView));
        }
        [RelayCommand]
        private async Task LogoutButtonClick()
        {
            AuthService.Logout();
            await DialogService.ShowAlert("Wylogowano", "Pomyślnie wylogowano");
            await Shell.Current.GoToAsync(nameof(UserView));
        }
        [RelayCommand]
        private async Task Appearing()
        {
            IsLogged = await AuthService.IsLogged();

            if (!IsLogged)
                return;

            await InitUser();
        }
        private async Task InitUser()
        {
            string userId = await SecureStorage.Default.GetAsync("userId");
            if (!int.TryParse(userId, out int parsedId))
                return;

            var user = await AuthService.GetUserById(parsedId);
            if (user == null) return;

            Name = user.Name;
            LastName = user.LastName;
            Login = user.Login;
            Email = user.Email;
        }
        private async Task InitCompany()
        {
            string userId = await SecureStorage.Default.GetAsync("userId");
            if (!int.TryParse(userId, out int parsedId))
                return;

            var user = await AuthService.GetUserById(parsedId);
            if (user == null) return;

            Name = user.Name;
            LastName = user.LastName;
            Login = user.Login;
            Email = user.Email;
        }
    }
}
