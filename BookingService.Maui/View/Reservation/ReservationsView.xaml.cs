using BookingService.Maui.ViewModel.Reservation;

namespace BookingService.Maui.View.Reservation;

public partial class ReservationsView : ContentPage
{
    public ReservationsView(ReservationsViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}