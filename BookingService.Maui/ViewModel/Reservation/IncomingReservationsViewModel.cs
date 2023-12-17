using BookingService.Maui.Model.Reservation;
using BookingService.Maui.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BookingService.Maui.ViewModel.Reservation
{
    public partial class IncomingReservationsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<IncomingReservation>? reservationList;

        [ObservableProperty]
        IncomingReservation? selectedReservation;

        [ObservableProperty]
        bool isLogged;

        private readonly IReservationService reservationService;

        public IncomingReservationsViewModel(IReservationService reservationService)
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

        [RelayCommand]
        private async Task ItemSelected()
        {
            if (SelectedReservation is null)
                return;

            List<string> options = new()
            {
                "Odwołaj"
            };
            string selectedOption = await DialogService.ShowOptionsDialog("Wybierz opcje", options);

            if (selectedOption == null)
                return;

            switch (selectedOption)
            {
                case "Odwołaj":
                    {
                        await DeleteReservation(SelectedReservation.Id);
                    }
                    break;
            }
        }

        private async Task DeleteReservation(int id)
        {
            var result = await reservationService.DeleteReservation(id);

            if (!result.Result)
            {
                await DialogService.ShowAlert("Niepowodzenie", "Nie udało się usunąć rezerwacji");
                return;
            }

            await DialogService.ShowAlert("Powodzenie", "Usunięto rezerwację");
            await Appearing();
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

            var reservations = await reservationService.GetIncomingReservationByUserId(parsedId);
            ReservationList = new ObservableCollection<IncomingReservation>(reservations.Value);
        }
    }
}
