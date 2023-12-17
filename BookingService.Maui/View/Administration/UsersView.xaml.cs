using BookingService.Maui.ViewModel.Administration;

namespace BookingService.Maui.View.Administration;

public partial class UsersView : ContentPage
{
    public UsersView(UsersViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Shell.SetTabBarIsVisible(this, false);
    }
}