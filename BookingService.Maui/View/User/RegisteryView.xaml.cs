using BookingService.Maui.ViewModel.User;

namespace BookingService.Maui.View.User;

public partial class RegisteryView : ContentPage
{
    public RegisteryView(RegisteryViewModel registeryViewModel)
    {
        InitializeComponent();
        BindingContext = registeryViewModel;
        Shell.SetTabBarIsVisible(this, false);
    }
}