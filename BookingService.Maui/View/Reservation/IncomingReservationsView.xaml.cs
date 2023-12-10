using BookingService.Maui.ViewModel.Reservation;

namespace BookingService.Maui.View.Reservation;

public partial class IncomingReservationsView : ContentPage
{
    public IncomingReservationsView(IncomingReservationsViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}