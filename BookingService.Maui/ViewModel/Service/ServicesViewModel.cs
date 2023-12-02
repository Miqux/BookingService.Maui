using BookingService.Maui.Model.Service;
using BookingService.Maui.Services.Interface;
using BookingService.Maui.View.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BookingService.Maui.ViewModel.Service
{
    public partial class ServicesViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<ServiceLight> servicesList;

        [ObservableProperty]
        ServiceLight selectedService = new();

        private readonly IServiceService serviceService;

        public ServicesViewModel(IServiceService serviceService)
        {
            this.serviceService = serviceService;
            ServicesList = new ObservableCollection<ServiceLight>();
        }

        [RelayCommand]
        private async Task Appearing()
        {
            await InitializeData();
        }
        public async Task InitializeData()
        {
            var services = await serviceService.GetServiceLight();
            ServicesList = new ObservableCollection<ServiceLight>(services.Value);
        }
        [RelayCommand]
        private async Task ItemSelected()
        {
            if (SelectedService is null)
                return;

            var temp = new Dictionary<string, object>
            {
                { "ServiceId", SelectedService.Id }
            };
            await Shell.Current.GoToAsync(nameof(ServiceDetalisView), temp);
        }
    }
}
