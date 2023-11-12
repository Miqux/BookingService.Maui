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
        }
    }
}