using BookingService.Maui.ViewModel.User;

namespace BookingService.Maui.View.User;

public partial class ComapnyView : ContentPage
{
    public ComapnyView(CompanyViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Shell.SetTabBarIsVisible(this, false);
    }
}