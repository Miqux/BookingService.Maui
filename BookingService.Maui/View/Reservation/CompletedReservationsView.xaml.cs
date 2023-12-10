using BookingService.Maui.ViewModel.Reservation;

namespace BookingService.Maui.View.Reservation;

public partial class CompletedReservationsView : ContentPage
{
    public CompletedReservationsView(CompletedReservationsViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}