﻿using System.Globalization;

namespace BookingService.Maui
{
    public partial class App : Application
    {
        private readonly AppShell _appShell;
        public App()
        {
            InitializeComponent();
            Application.Current.UserAppTheme = AppTheme.Light;
            var culture = new CultureInfo("pl-PL");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            _appShell = Provider.ServiceProvider.GetService<AppShell>();
            MainPage = _appShell;
        }
    }
}