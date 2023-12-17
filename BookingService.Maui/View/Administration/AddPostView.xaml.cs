using BookingService.Maui.ViewModel.Administration;

namespace BookingService.Maui.View.Administration;

public partial class AddPostView : ContentPage
{
    public AddPostView(AddPostViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Shell.SetTabBarIsVisible(this, false);
    }
}