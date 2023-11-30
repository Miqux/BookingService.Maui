using BookingService.Maui.ViewModel.Service;

namespace BookingService.Maui.View.Service;

public partial class ServiceDetalisView : ContentPage
{
    public ServiceDetalisView(ServiceDetalisViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Shell.SetTabBarIsVisible(this, false);
    }
}