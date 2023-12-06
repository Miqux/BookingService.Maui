using BookingService.Maui.ViewModel.Company;

namespace BookingService.Maui.View.Company;

public partial class EditCompanyView : ContentPage
{
    public EditCompanyView(EditCompanyViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Shell.SetTabBarIsVisible(this, false);
    }
}