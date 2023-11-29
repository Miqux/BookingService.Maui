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
        //[ObservableProperty]
        //CompanyService selectedService = new();
        [ObservableProperty]
        CompanyService selectedService = new();
        [ObservableProperty]
        int comapnyId;

        private ObservableCollection<CompanyService> servicesList;
        public ObservableCollection<CompanyService> ServicesList
        {
            get => servicesList;
            set => SetProperty(ref servicesList, value);
        }

        private readonly IServiceService serviceService;

        public CompanyServicesViewModel(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [RelayCommand]
        public async Task Appearing()
        {
            var services = await serviceService.GetCompanyServices(ComapnyId);
            ServicesList = new ObservableCollection<CompanyService>(services.Value);
            //await InitalizeData();
        }

        [RelayCommand]
        public async Task AddServiceButtonClick()
        {

            await Shell.Current.GoToAsync(nameof(AddCompanyServiceView));
        }
        [RelayCommand]
        private async Task ItemSelected(object item)
        {
            if (item == null)
                return;

            CompanyService service = (CompanyService)item;
            List<string> options = new()
            {
                "Usuń",
                "Edytuj"
            };
            string selectedOption = await DialogService.ShowOptionsDialog("Wybierz opcje", options);

            if (selectedOption == null)
                return;

            switch (selectedOption)
            {
                case "Usuń":
                    {
                        await DeleteService(service.Id);
                    }
                    break;
            }
        }

        public async Task InitalizeData()
        {

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
        }

    }
}
