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
        private async void Temp()
        {
            var temp = await userService.Login("test1234", "test1234");
            var temp2 = await addressService.GetAll();
        }
    }
}
