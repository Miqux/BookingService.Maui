using BookingService.Maui.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookingService.Maui.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        public readonly IAuthService AuthService = Provider.ServiceProvider.GetService<IAuthService>();
        public readonly IDialogService DialogService = Provider.ServiceProvider.GetService<IDialogService>();
    }
}
