using BookingService.Maui.Model;
using BookingService.Maui.Model.Reservation;
using BookingService.Maui.Model.Service;
using BookingService.Maui.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookingService.Maui.ViewModel.Service
{
    [QueryProperty("ServiceId", "ServiceId")]
    public partial class ServiceDetalisViewModel : BaseViewModel
    {
        [ObservableProperty]
        public DateTime selectedDate = DateTime.Today;

        [ObservableProperty]
        bool isLogged;

        [ObservableProperty]
        int serviceId;

        [ObservableProperty]
        ServiceDetails? serviceDetails;

        [ObservableProperty]
        string selectedTime = "Wybierz godzinę";

        [ObservableProperty]
        ServiceTime? selectedServiceTime;

        private readonly IServiceService serviceService;
        private readonly IReservationService reservationService;

        public ServiceDetalisViewModel(IServiceService serviceService, IReservationService reservationService)
        {
            this.serviceService = serviceService;
            this.reservationService = reservationService;
        }
        partial void OnSelectedDateChanged(DateTime value)
        {
            SelectedTime = "Wybierz godzinę";
            SelectedServiceTime = null;
        }
        [RelayCommand]
        public async Task Appearing()
        {
            IsBusy = true;
            var serviceDetalis = await serviceService.GetServiceDetalis(ServiceId);
            ServiceDetails = serviceDetalis.Value;
            IsLogged = await AuthService.IsLogged();
            IsBusy = false;
        }

        [RelayCommand]
        public async Task ReservationButtonClick()
        {
            if (IsBusy)
                return;

            if (SelectedServiceTime is null)
            {
                await DialogService.ShowAlert("", "Wybierz godzinę");
                return;
            }

            if (!int.TryParse(await SecureStorage.Default.GetAsync("userId"), out int userId))
                return;

            Reservation reservation = new()
            {
                UserId = userId,
                ServiceId = ServiceId,
                StartDateAndTime = SelectedDate.Add(SelectedServiceTime.StartTime),
                EndDateAndTime = SelectedDate.Add(SelectedServiceTime.EndTime)
            };

            IsBusy = true;
            var result = await reservationService.AddReservation(reservation);
            IsBusy = false;

            if (result is null || !result.Result)
            {
                await DialogService.ShowAlert("Błąd", "Nie udało się dodać rezerwacji");
                return;
            }
            await DialogService.ShowAlert("Powodzenie", "Dodano rezerwację");
            await Shell.Current.Navigation.PopAsync();
        }

        [RelayCommand]
        public async Task ReservationTimeButtonClick()
        {
            IsBusy = true;
            var possibleHours = await serviceService.GetPossibleServiceHours(ServiceId, DateOnly.FromDateTime(SelectedDate));
            IsBusy = false;
            if (possibleHours is null || !possibleHours.Result)
            {
                await DialogService.ShowAlert("Błąd", possibleHours?.Message ?? "Błąd");
                return;
            }

            List<string> timeList = new();

            foreach (var item in possibleHours.Value)
            {
                string time = item.StartTime.ToString(@"hh\:mm") + " : " + item.EndTime.ToString(@"hh\:mm");
                timeList.Add(time);
            }

            var temp = await DialogService.ShowOptionsDialog("Wybierz godzine", timeList);

            if (temp == null || temp == "Zamknij")
                return;

            string[] timeStrings = temp.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string startString = timeStrings[0] + ":" + timeStrings[1] + ":00";
            startString = startString.Replace(" ", "");
            string endString = timeStrings[2] + ":" + timeStrings[3] + ":00";
            TimeSpan startTime;
            TimeSpan endTime;

            bool success = TimeSpan.TryParse(startString, out startTime);
            success = TimeSpan.TryParse(endString, out endTime);

            if (!success)
                return;

            SelectedServiceTime = new()
            {
                StartTime = startTime,
                EndTime = endTime,
            };

            SelectedTime = temp;

        }
    }
}
