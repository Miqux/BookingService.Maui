using BookingService.Maui.ViewModel.App;
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
            builder.Services.AddScoped<AppShell>();
            builder.Services.AddScoped<AppShellViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();
            Provider.ServiceProvider.Initialize(app.Services);
            return app;
        }
    }
}