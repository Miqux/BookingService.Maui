using BookingService.Maui.Helpers;
using BookingService.Maui.Repository.Interface;
using BookingService.Maui.Repository.Repository;
using BookingService.Maui.Services.Interface;
using BookingService.Maui.Services.Services;
using BookingService.Maui.View.User;
using BookingService.Maui.ViewModel.App;
using BookingService.Maui.ViewModel.User;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace BookingService.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddScoped(sp =>
            {
                HttpClient httpClient = new(new JwtAuthHandler())
                {
                    BaseAddress = new Uri("https://localhost:7146/api/"),
                    Timeout = TimeSpan.FromSeconds(20)
                };
                return httpClient;
            });
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<AppShellViewModel>();
            builder.Services.AddTransient<UserView>();
            builder.Services.AddTransient<UserViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginView>();

            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<IAddressService, AddressService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();
            Provider.ServiceProvider.Initialize(app.Services);
            return app;
        }
    }
}