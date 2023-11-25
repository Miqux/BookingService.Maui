using BookingService.Maui.ViewModel.Service;

namespace BookingService.Maui.View.Service;

public partial class ServicesView : ContentPage
{
    public ServicesView(ServicesViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}