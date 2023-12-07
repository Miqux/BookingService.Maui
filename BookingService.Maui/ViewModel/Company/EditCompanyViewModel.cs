using BookingService.Maui.Model.Company;
using BookingService.Maui.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Maui.ViewModel.Company
{
    public partial class EditCompanyViewModel : BaseValidatorViewModel, IQueryAttributable
    {
        #region ValidationProperty
        [Required(ErrorMessage = "Nazwa jest wymagana!")]
        [MinLength(3, ErrorMessage = "Nazwa powinna zawierać conajmniej 3 znaki!")]
        [MaxLength(20, ErrorMessage = "Nazwa nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string companyName = string.Empty;

        [Required(ErrorMessage = "Ulica jest wymagana!")]
        [MinLength(3, ErrorMessage = "Ulica powinna zawierać conajmniej 3 znaki!")]
        [MaxLength(20, ErrorMessage = "Ulica nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string street = string.Empty;

        [Required(ErrorMessage = "Miasto jest wymagane!")]
        [MinLength(3, ErrorMessage = "Miasto powinno zawierać conajmniej 3 znaki!")]
        [MaxLength(20, ErrorMessage = "Miasto nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string city = string.Empty;

        [Required(ErrorMessage = "Kod pocztowy jest wymagany!")]
        [StringLength(6, ErrorMessage = "Kod pocztowy powinien zawierać 6 znaków")]
        [ObservableProperty]
        string zipcode = string.Empty;

        [Required(ErrorMessage = "Numer domu jest wymagany!")]
        [ObservableProperty]
        int houseNumber;

        [ObservableProperty]
        int? apartmentNumber;

        #endregion       

        [ObservableProperty]
        UpdateCompany? model;

        private readonly ICompanyService companyService;

        public EditCompanyViewModel(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [RelayCommand]
        public async Task Appearing()
        {
            if (Model is null)
            {
                await DialogService.ShowAlert("Błąd", "Brak firmy");
                return;
            }
            CompanyName = Model.CompanyName;
            Zipcode = Model.Zipcode;
            Street = Model.Street;
            City = Model.City;
            HouseNumber = Model.HouseNumber;
            ApartmentNumber = Model.ApartmentNumber;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Model = query["Model"] as UpdateCompany;
        }

        [RelayCommand]
        public async Task EditCompanyButtonClick()
        {
            var validation = Validate();
            if (!validation.Item1)
            {
                await DialogService.ShowAlert("Niepoprawne dane", validation.Item2);
                return;
            }

            if (Model is null)
                return;

            UpdateCompany model = new()
            {
                CompanyId = Model.CompanyId,
                CompanyName = CompanyName,
                Zipcode = Zipcode,
                Street = Street,
                City = City,
                HouseNumber = HouseNumber,
                ApartmentNumber = ApartmentNumber
            };

            IsBusy = true;
            var result = await companyService.UpdateCompany(model);
            IsBusy = false;

            if (!result.Result)
            {
                await DialogService.ShowAlert("Niepoprawne dane", result.Message);
                return;
            }
            await DialogService.ShowAlert("Pomyślnie", "Zaaktualizowano dane firmy");
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
