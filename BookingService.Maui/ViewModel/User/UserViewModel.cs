﻿using BookingService.Maui.View.User;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookingService.Maui.ViewModel.User
{
    public partial class UserViewModel : BaseViewModel
    {
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

        [RelayCommand]
        private async Task LoginButtonClick()
        {
            await Shell.Current.GoToAsync(nameof(LoginView));
        }
        [RelayCommand]
        private async Task LogoutButtonClick()
        {
            await AuthService.Logout();
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
    }
}
