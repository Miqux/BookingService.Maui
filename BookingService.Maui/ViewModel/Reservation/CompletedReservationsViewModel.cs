using BookingService.Maui.Model.Reservation;
using BookingService.Maui.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BookingService.Maui.ViewModel.Reservation
{
    public partial class CompletedReservationsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<CompletedReservation>? reservationList;

        [ObservableProperty]
        bool isLogged;

        private readonly IReservationService reservationService;

        public CompletedReservationsViewModel(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [RelayCommand]
        public async Task Appearing()
        {
            IsBusy = true;
            await InitalizeData();
            IsBusy = false;
        }

        public async Task InitalizeData()
        {
            IsLogged = await AuthService.IsLogged();
            if (!IsLogged)
            {
                ReservationList = null;
                return;
            }

            string userId = await SecureStorage.Default.GetAsync("userId");
            if (!int.TryParse(userId, out int parsedId))
                return;

            var reservations = await reservationService.GetCompletedReservationByUserId(parsedId);
            ReservationList = new ObservableCollection<CompletedReservation>(reservations.Value);
        }
    }
}
