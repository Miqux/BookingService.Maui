using BookingService.Maui.Services.Interface;
using BookingService.Maui.View.User;
using CommunityToolkit.Mvvm.Input;

namespace BookingService.Maui.ViewModel.User
{
    public partial class UserViewModel : BaseViewModel
    {
        private readonly IAuthService userService;
        private readonly IAddressService addressService;

        public UserViewModel(IAuthService userService, IAddressService addressService)
        {
            this.userService = userService;
            this.addressService = addressService;
        }
        [RelayCommand]
        private async Task Temp()
        {
            await Shell.Current.GoToAsync(nameof(LoginView));
        }
    }
}
