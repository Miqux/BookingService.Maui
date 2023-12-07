using BookingService.Maui.Services.Interface;

namespace BookingService.Maui.Configuration
{
    public class NetworkConnectivity
    {
        private readonly IDialogService dialogService;

        public NetworkConnectivity(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        public async void Connectivity_ConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
        {
            if (sender != null) return;

            if (e.NetworkAccess != NetworkAccess.Internet)
            {
                Thread.Sleep(3000);
                while (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                    await dialogService.ShowAlert("Utracono połączenie", "Aby korzystać z aplikacji, odnów połączenie.");
            }

        }
    }
}
