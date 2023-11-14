using BookingService.Maui.ViewModel.User;

namespace BookingService.Maui.View.User;

public partial class LoginView : ContentPage
{
    LoginViewModel _loginViewModel;
    public LoginView(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        _loginViewModel = loginViewModel;
    }
}