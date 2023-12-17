using BookingService.Maui.Services.Interface;
using BookingService.Maui.View.Administration;
using BookingService.Maui.View.Company;
using BookingService.Maui.View.Main;
using BookingService.Maui.View.Reservation;
using BookingService.Maui.View.Service;
using BookingService.Maui.View.User;
using BookingService.Maui.ViewModel.App;

namespace BookingService.Maui
{
    public partial class AppShell : Shell
    {
        AppShellViewModel _appShellViewModel;
        private readonly IDialogService dialogService;

        public AppShell(AppShellViewModel appShellViewModel, IDialogService dialogService)
        {
            InitializeComponent();
            _appShellViewModel = appShellViewModel;
            this.dialogService = dialogService;
            Routing.RegisterRoute(nameof(MainView), typeof(MainView));
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(UserView), typeof(UserView));
            Routing.RegisterRoute(nameof(RegisteryView), typeof(RegisteryView));
            Routing.RegisterRoute(nameof(ServicesView), typeof(ServicesView));
            Routing.RegisterRoute(nameof(CompanyServicesView), typeof(CompanyServicesView));
            Routing.RegisterRoute(nameof(AddCompanyServiceView), typeof(AddCompanyServiceView));
            Routing.RegisterRoute(nameof(ServiceDetalisView), typeof(ServiceDetalisView));
            Routing.RegisterRoute(nameof(EditCompanyView), typeof(EditCompanyView));
            Routing.RegisterRoute(nameof(CompletedReservationsView), typeof(CompletedReservationsView));
            Routing.RegisterRoute(nameof(IncomingReservationsView), typeof(IncomingReservationsView));
            Routing.RegisterRoute(nameof(UsersView), typeof(UsersView));
            Routing.RegisterRoute(nameof(AddPostView), typeof(AddPostView));

            BindingContext = _appShellViewModel;
        }
    }
}