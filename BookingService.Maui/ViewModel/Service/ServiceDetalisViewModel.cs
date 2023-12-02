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
        public string minDate = DateTime.Today.ToString("MM/dd/yyyy");

        [ObservableProperty]
        public string maxDate = DateTime.Today.AddYears(1).ToString("MM/dd/yyyy");

        [ObservableProperty]
        public DateTime selectedDate = DateTime.Today;

        [ObservableProperty]
        bool isLogged;

        [ObservableProperty]
        int serviceId;

        [ObservableProperty]
        ServiceDetails? serviceDetails;

        private readonly IServiceService serviceService;

        public ServiceDetalisViewModel(IServiceService serviceService)
        {
            this.serviceService = serviceService;
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
    }
}
