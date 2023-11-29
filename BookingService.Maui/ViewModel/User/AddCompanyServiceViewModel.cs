using BookingService.Maui.Helpers;
using BookingService.Maui.Model;
using BookingService.Maui.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Maui.ViewModel.User
{
    public partial class AddCompanyServiceViewModel : BaseValidatorViewModel
    {
        #region ValidationProperty
        [Required(ErrorMessage = "Nazwa jest wymagana!")]
        [MinLength(3, ErrorMessage = "Nazwa powinna zawierać conajmniej 3 znaki!")]
        [MaxLength(20, ErrorMessage = "Nazwa nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string name = string.Empty;

        [Required(ErrorMessage = "Koszt jest wymagany!")]
        [ObservableProperty]
        decimal cost;

        [Required(ErrorMessage = "Koszt jest wymagany!")]
        [ObservableProperty]
        int durationInMinutes;

        [ObservableProperty]
        ObservableCollection<IdName> types;

        [Required(ErrorMessage = "Typ usługi nie może być pusty")]
        [ObservableProperty]
        IdName type;

        #endregion

        private readonly IServiceService serviceService;

        public AddCompanyServiceViewModel(IServiceService serviceService)
        {
            Types = new ObservableCollection<IdName>(Extension.GetListFromEnum<Enums.ServiceType>());
            this.serviceService = serviceService;
            Type = new() { Name = Enums.ServiceType.Combo.GetDescription(), Id = (int)Enums.ServiceType.Combo };
        }

        [RelayCommand]
        public async Task AddServiceButtonClick()
        {
            var validation = Validate();
            if (!validation.Item1)
            {
                await DialogService.ShowAlert("Niepoprawne dane", validation.Item2);
                return;
            }

            if (!int.TryParse(await SecureStorage.Default.GetAsync("companyId"), out int companyId))
                return;

            Model.Service.Service service = new()
            {
                Name = Name,
                Cost = Cost,
                DurationInMinutes = DurationInMinutes,
                Type = (Enums.ServiceType)Type.Id,
                CompanyId = companyId
            };

            var result = await serviceService.AddService(service);

            if (!result.Result)
            {
                await DialogService.ShowAlert("Błąd", result.Message);
                return;
            }
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
