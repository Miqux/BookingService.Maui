using BookingService.Maui.Model.Address;
using BookingService.Maui.Services.Interface;
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
        Address address = new();

        #endregion

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
            IsLogged = await AuthService.IsLogged();
            if (!IsLogged)
                return;

            await InitUser();
            await InitCompany();
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
            var address = await addressService.GetById(company.Value.Id);

            if (!address.Result)
                return;

            CompanyName = company.Value.Name;
            Address = address.Value;
        }
    }
}
