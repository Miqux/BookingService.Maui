using BookingService.Maui.ViewModel.Main;

namespace BookingService.Maui.View.Main;

public partial class MainView : ContentPage
{
    public MainView(MainViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}