namespace BookingService.Maui
{
    public partial class App : Application
    {
        private readonly AppShell _appShell;
        public App()
        {
            InitializeComponent();
            _appShell = Provider.ServiceProvider.GetService<AppShell>();
            Application.Current.UserAppTheme = AppTheme.Light;
            MainPage = _appShell;
        }
    }
}