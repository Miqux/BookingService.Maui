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
            InitializeData();
        }
        public void InitializeData()
        {
            var services = serviceService.GetServiceLight().Result.Value;
            ServicesList = new ObservableCollection<ServiceLight>(services);
        }
        [RelayCommand]
        private async Task ItemSelected(object item)
        {
        }
    }
}
