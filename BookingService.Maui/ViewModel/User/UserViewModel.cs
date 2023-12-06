using BookingService.Maui.Model.Address;
using BookingService.Maui.Model.Company;
using BookingService.Maui.Services.Interface;
using BookingService.Maui.View.Company;
using BookingService.Maui.View.User;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookingService.Maui.ViewModel.User
{
    public partial class UserViewModel : BaseViewModel
    {
        #region ObservableProperty

        [ObservableProperty]
        bool isLogged;
        [ObservableProperty]
        string name = string.Empty;
        [ObservableProperty]
        string login = string.Empty;
        [ObservableProperty]
        string lastName = string.Empty;
        [ObservableProperty]
        string email = string.Empty;

        [ObservableProperty]
        bool isCompany;
        [ObservableProperty]
        string companyName = string.Empty;
        [ObservableProperty]
        Address? address;

        #endregion

        private CompanyLight companyValue;
        private int companyId;

        private readonly IAddressService addressService;
        private readonly ICompanyService companyService;

        public UserViewModel(IAddressService addressService, ICompanyService companyService)
        {
            this.addressService = addressService;
            this.companyService = companyService;
        }

        [RelayCommand]
        private async Task LoginButtonClick()
        {
            await Shell.Current.GoToAsync(nameof(LoginView));
        }

        [RelayCommand]
        private async Task LogoutButtonClick()
        {
            AuthService.Logout();
            await DialogService.ShowAlert("Wylogowano", "Pomyślnie wylogowano");
            await Shell.Current.GoToAsync(nameof(UserView));
        }

        [RelayCommand]
        private async Task Appearing()
        {
            try
            {
                IsBusy = true;
                IsLogged = await AuthService.IsLogged();
                if (!IsLogged)
                    return;

                await InitUser();
                await InitCompany();
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task CompanyServicesButtonClick()
        {
            var temp = new Dictionary<string, object>
            {
                { "ComapnyId", companyId }
            };
            await Shell.Current.GoToAsync(nameof(CompanyServicesView), temp);
        }

        [RelayCommand]
        private async Task EditCompanyButtonClick()
        {
            UpdateCompany model = new();

            if (companyValue is null || Address is null)
                return;

            model.CompanyId = companyValue.Id;
            model.CompanyName = companyValue.Name;
            model.ApartmentNumber = Address.ApartmentNumber;
            model.HouseNumber = Address.HouseNumber;
            model.City = Address.City;
            model.Street = Address.Street;
            model.Zipcode = Address.Zipcode;

            var temp = new Dictionary<string, object>
            {
                { "Model", model }
            };
            await Shell.Current.GoToAsync(nameof(EditCompanyView), temp);
        }

        private async Task InitUser()
        {
            string userId = await SecureStorage.Default.GetAsync("userId");
            if (!int.TryParse(userId, out int parsedId))
                return;

            var user = await AuthService.GetUserById(parsedId);
            if (user == null) return;

            Name = user.Name;
            LastName = user.LastName;
            Login = user.Login;
            Email = user.Email;
        }

        private async Task InitCompany()
        {
            bool isCompanyBoss = await AuthService.IsCompanyBoss();

            string userId = await SecureStorage.Default.GetAsync("userId");
            if (!int.TryParse(userId, out int parsedId))
                return;

            var company = await companyService.GetByUserId(parsedId);

            if (!company.Result || company.Value is null || !isCompanyBoss)
            {
                IsCompany = false;
                return;
            }

            companyId = company.Value.Id;
            await SecureStorage.Default.SetAsync("companyId", company.Value.Id.ToString());

            IsCompany = true;
            var address = await addressService.GetById(company.Value.AddressId);

            if (!address.Result)
                return;

            companyValue = company.Value;
            CompanyName = company.Value.Name;
            Address = address.Value;
        }
    }
}
