﻿using AutoMapper;
using BookingService.Maui.Configuration;
using BookingService.Maui.Helpers;
using BookingService.Maui.Repository.Interface;
using BookingService.Maui.Repository.Repository;
using BookingService.Maui.Services.Interface;
using BookingService.Maui.Services.Services;
using BookingService.Maui.View.Administration;
using BookingService.Maui.View.Company;
using BookingService.Maui.View.Main;
using BookingService.Maui.View.Reservation;
using BookingService.Maui.View.Service;
using BookingService.Maui.View.User;
using BookingService.Maui.ViewModel.Administration;
using BookingService.Maui.ViewModel.App;
using BookingService.Maui.ViewModel.Company;
using BookingService.Maui.ViewModel.Main;
using BookingService.Maui.ViewModel.Reservation;
using BookingService.Maui.ViewModel.Service;
using BookingService.Maui.ViewModel.User;
using CommunityToolkit.Maui;

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
            builder.Services.AddSingleton<HttpSendHandler>();
            builder.Services.AddHttpClient("BookingServiceApi", client =>
            {
                client.BaseAddress = new Uri("https://booking-service-api.azurewebsites.net/api/");
                //client.BaseAddress = new Uri("http://10.0.2.2:5233/api/");
                client.Timeout = TimeSpan.FromSeconds(12);
            }).ConfigurePrimaryHttpMessageHandler<HttpSendHandler>();

            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<AppShellViewModel>();

            builder.Services.AddSingleton<NetworkConnectivity>();

            builder.Services.AddTransient<UserView>();
            builder.Services.AddTransient<UserViewModel>();

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginView>();

            builder.Services.AddTransient<RegisteryViewModel>();
            builder.Services.AddTransient<RegisteryView>();

            builder.Services.AddTransient<ServicesView>();
            builder.Services.AddTransient<ServicesViewModel>();

            builder.Services.AddTransient<CompanyServicesView>();
            builder.Services.AddTransient<CompanyServicesViewModel>();

            builder.Services.AddTransient<AddCompanyServiceView>();
            builder.Services.AddTransient<AddCompanyServiceViewModel>();

            builder.Services.AddTransient<ServiceDetalisView>();
            builder.Services.AddTransient<ServiceDetalisViewModel>();

            builder.Services.AddTransient<EditCompanyView>();
            builder.Services.AddTransient<EditCompanyViewModel>();

            builder.Services.AddTransient<CompletedReservationsView>();
            builder.Services.AddTransient<CompletedReservationsViewModel>();

            builder.Services.AddTransient<IncomingReservationsView>();
            builder.Services.AddTransient<IncomingReservationsViewModel>();

            builder.Services.AddTransient<UsersView>();
            builder.Services.AddTransient<UsersViewModel>();

            builder.Services.AddTransient<MainView>();
            builder.Services.AddTransient<MainViewModel>();

            builder.Services.AddTransient<AddPostView>();
            builder.Services.AddTransient<AddPostViewModel>();

            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();

            builder.Services.AddScoped<IAddressService, AddressService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IDialogService, DialogService>();
            builder.Services.AddScoped<IServiceService, ServiceService>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<IPostService, PostService>();

            SecureStorage.Default.RemoveAll();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfiguration());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();
            Provider.ServiceProvider.Initialize(app.Services);
            return app;
        }
    }
}