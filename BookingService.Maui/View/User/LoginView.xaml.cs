using BookingService.Maui.ViewModel.User;

namespace BookingService.Maui.View.User;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        BindingContext = loginViewModel;
        Shell.SetTabBarIsVisible(this, false);
    }
}