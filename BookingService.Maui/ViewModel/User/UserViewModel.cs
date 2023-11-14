using BookingService.Maui.Services.Interface;
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
        private void Temp()
        {
            var temp = userService.Login("", "");
            var temp2 = addressService.GetAll();
        }
    }
}
