using BookingService.Maui.View.Company;
using BookingService.Maui.View.Service;
using BookingService.Maui.View.User;
using BookingService.Maui.ViewModel.App;

namespace BookingService.Maui
{
    public partial class AppShell : Shell
    {
        AppShellViewModel _appShellViewModel;
        public AppShell(AppShellViewModel appShellViewModel)
        {
            InitializeComponent();
            _appShellViewModel = appShellViewModel;
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(UserView), typeof(UserView));
            Routing.RegisterRoute(nameof(RegisteryView), typeof(RegisteryView));
            Routing.RegisterRoute(nameof(ServicesView), typeof(ServicesView));
            Routing.RegisterRoute(nameof(CompanyServicesView), typeof(CompanyServicesView));
            Routing.RegisterRoute(nameof(AddCompanyServiceView), typeof(AddCompanyServiceView));
            Routing.RegisterRoute(nameof(ServiceDetalisView), typeof(ServiceDetalisView));
            Routing.RegisterRoute(nameof(EditCompanyView), typeof(EditCompanyView));
            BindingContext = _appShellViewModel;
        }
    }
}