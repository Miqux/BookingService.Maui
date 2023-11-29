using BookingService.Maui.ViewModel.User;

namespace BookingService.Maui.View.User;

public partial class CompanyServicesView : ContentPage
{
    public CompanyServicesView(CompanyServicesViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Shell.SetTabBarIsVisible(this, false);
    }
}