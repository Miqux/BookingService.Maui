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

        private readonly IServiceService serviceService;

        public ServiceDetalisViewModel(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }
        partial void OnSelectedDateChanged(DateTime value)
        {

        }
        [RelayCommand]
        public async Task Appearing()
        {
            var serviceDetalis = await serviceService.GetServiceDetalis(ServiceId);
            ServiceDetails = serviceDetalis.Value;
            IsLogged = await AuthService.IsLogged();
        }

        [RelayCommand]
        public async Task ReservationButtonClick()
        {

        }
        [RelayCommand]
        public async Task ReservationTimeButtonClick()
        {
            List<string> timeList = new();

            timeList.Add("12:00");
            timeList.Add("14:00");
            timeList.Add("16:00");
            timeList.Add("18:00");

            var temp = await DialogService.ShowOptionsDialog("Wybierz godzine", timeList);

            if (temp == null || temp == "Zamknij")
                return;

            SelectedTime = temp;
        }
    }
}
