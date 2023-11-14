using BookingService.Maui.ViewModel.User;

namespace BookingService.Maui.View.User;

public partial class UserView : ContentPage
{
    public UserView(UserViewModel userViewModel)
    {
        InitializeComponent();
        BindingContext = userViewModel;
    }
}