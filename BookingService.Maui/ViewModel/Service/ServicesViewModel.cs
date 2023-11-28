using BookingService.Maui.Model.Service;
using BookingService.Maui.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BookingService.Maui.ViewModel.Service
{
    public partial class ServicesViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<ServiceLight>? servicesList;

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
            //var services = serviceService.GetServiceLight().Result.Value;
            List<ServiceLight> services = new List<ServiceLight>();
            ServiceLight serviceLight = new ServiceLight() { ComapnyName = "testowa firma", Name = "testowa usługa", Type = Model.Enums.ServiceType.Combo };
            services.Add(serviceLight);
            ServiceLight serviceLight2 = new ServiceLight() { ComapnyName = "testowa2 firma2", Name = "testasdowa usługa", Type = Model.Enums.ServiceType.Haircut };
            services.Add(serviceLight2);
            ServiceLight serviceLight3 = new ServiceLight() { ComapnyName = "testow3a firma3", Name = "testowa ", Type = Model.Enums.ServiceType.BeardTrimming };
            services.Add(serviceLight3);
            ServicesList = new ObservableCollection<ServiceLight>(services);
        }
        [RelayCommand]
        private async Task ItemSelected(object item)
        {
        }
    }
}
