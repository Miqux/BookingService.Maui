using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Reservation;
using BookingService.Maui.Model.ApiResponse;

namespace BookingService.Maui.Repository.Interface
{
    public interface IReservationRepository
    {
        public Task<ResultModel<BaseCommandResponse>> AddReservation(AddReservationRequest model);
    }
}
