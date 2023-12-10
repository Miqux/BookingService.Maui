using CommunityToolkit.Mvvm.Input;

namespace BookingService.Maui.ViewModel.Reservation
{
    public partial class CompletedReservationsViewModel : BaseViewModel
    {

        [RelayCommand]
        public async Task Appearing()
        {
            IsBusy = true;
            await InitalizeData();
            IsBusy = false;
        }
        public async Task InitalizeData()
        {

        }
    }
}
