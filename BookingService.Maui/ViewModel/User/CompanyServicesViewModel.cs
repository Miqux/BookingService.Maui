using BookingService.Maui.Model.Service;
using BookingService.Maui.Services.Interface;
using BookingService.Maui.View.User;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BookingService.Maui.ViewModel.User
{
    [QueryProperty("ComapnyId", "ComapnyId")]
    public partial class CompanyServicesViewModel : BaseViewModel
    {
        [ObservableProperty]
        CompanyService selectedService = new();

        [ObservableProperty]
        int comapnyId;

        [ObservableProperty]
        private ObservableCollection<CompanyService> servicesList;

        private readonly IServiceService serviceService;

        public CompanyServicesViewModel(IServiceService serviceService)
        {
            this.serviceService = serviceService;
            ServicesList = new();
        }

        [RelayCommand]
        public async Task Appearing()
        {
            IsBusy = true;
            await InitalizeData();
            IsBusy = false;
        }

        [RelayCommand]
        public async Task AddServiceButtonClick()
        {

            await Shell.Current.GoToAsync(nameof(AddCompanyServiceView));
        }

        [RelayCommand]
        private async Task ItemSelected()
        {
            if (SelectedService == null)
                return;

            List<string> options = new()
            {
                "Usuń"
            };
            string selectedOption = await DialogService.ShowOptionsDialog("Wybierz opcje", options);

            if (selectedOption == null)
                return;

            switch (selectedOption)
            {
                case "Usuń":
                    {
                        await DeleteService(SelectedService.Id);
                    }
                    break;
            }
        }

        public async Task InitalizeData()
        {
            var services = await serviceService.GetCompanyServices(ComapnyId);
            ServicesList = new ObservableCollection<CompanyService>(services.Value);
        }

        private async Task DeleteService(int id)
        {
            var dialogResult = await DialogService.ShowYesOrNoDialog("Usuwanie", "Czy chcesz usunąć usługę?");
            if (!dialogResult)
                return;

            var response = await serviceService.DeleteService(id);
            if (!response.Result)
            {
                await DialogService.ShowAlert("Błąd", response.Message);
                return;
            }
            await DialogService.ShowAlert("Usunięto", "Pomyślnie usunięto usługę");
            await Appearing();
        }

    }
}
