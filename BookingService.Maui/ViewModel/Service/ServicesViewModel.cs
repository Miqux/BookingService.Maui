using BookingService.Maui.Helpers;
using BookingService.Maui.Model;
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

        [ObservableProperty]
        ObservableCollection<IdName> types;

        [ObservableProperty]
        IdName type;

        [ObservableProperty]
        string? city;

        private readonly IServiceService serviceService;

        public ServicesViewModel(IServiceService serviceService)
        {
            this.serviceService = serviceService;
            ServicesList = new ObservableCollection<ServiceLight>();
            var temp = Extension.GetListFromEnum<Enums.ServiceType>();
            temp.Add(new IdName() { Id = 0, Name = "Brak" });
            Types = new ObservableCollection<IdName>(temp);
            Type = new IdName() { Id = 0, Name = "Brak" };
        }

        [RelayCommand]
        private async Task Appearing()
        {
            IsBusy = true;
            await InitializeData();
            IsBusy = false;
        }
        public async Task InitializeData()
        {
            Type = Types.FirstOrDefault(x => x.Id == 0);
            var services = await serviceService.GetServiceLight(null, null);
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

        [RelayCommand]
        private async Task FilterButtonClick()
        {
            IsBusy = true;
            var services = await serviceService.GetServiceLight(Type.Id == 0 ? null : Type.Id, city);
            ServicesList = new ObservableCollection<ServiceLight>(services.Value);
            IsBusy = false;
        }
    }
}
