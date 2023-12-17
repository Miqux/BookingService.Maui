using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Reservation;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.ApiResponse.Reservation;

namespace BookingService.Maui.Repository.Interface
{
    public interface IReservationRepository
    {
        public Task<ResultModel<BaseCommandResponse>> AddReservation(AddReservationRequest model);
        public Task<ResultModel<BaseCommandResponse>> DeleteReservation(int id);
        public Task<ResultModel<List<IncomingReservationViewModel>>> GetIncomingReservationByUserId(int userId);
        public Task<ResultModel<List<CompletedReservationViewModel>>> GetCompletedReservationByUserId(int userId);
    }
}
