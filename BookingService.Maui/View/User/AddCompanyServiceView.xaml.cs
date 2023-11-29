using BookingService.Maui.ViewModel.User;

namespace BookingService.Maui.View.User;

public partial class AddCompanyServiceView : ContentPage
{
    public AddCompanyServiceView(AddCompanyServiceViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Shell.SetTabBarIsVisible(this, false);
    }
}