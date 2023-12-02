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
        private ObservableCollection<ServiceLight> servicesList;
        public ObservableCollection<ServiceLight> ServicesList
        {
            get => servicesList;
            set => SetProperty(ref servicesList, value);
        }
        [ObservableProperty]
        ServiceLight selectedService = new();

        private readonly IServiceService serviceService;

        public ServicesViewModel(IServiceService serviceService)
        {
            this.serviceService = serviceService;
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
        private async Task ItemSelected(object item)
        {
            if (item is null)
                return;

            ServiceLight serviceLight = (ServiceLight)item;

            var temp = new Dictionary<string, object>
            {
                { "ServiceId", serviceLight.Id }
            };
            await Shell.Current.GoToAsync(nameof(ServiceDetalisView), temp);
        }
    }
}
