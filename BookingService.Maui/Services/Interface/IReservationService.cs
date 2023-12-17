using BookingService.Maui.Model;
using BookingService.Maui.Model.Reservation;

namespace BookingService.Maui.Services.Interface
{
    public interface IReservationService
    {
        public Task<ResultModel<int?>> AddReservation(Reservation model);
        public Task<ResultModel<bool>> DeleteReservation(int id);
        public Task<ResultModel<List<IncomingReservation>>> GetIncomingReservationByUserId(int userId);
        public Task<ResultModel<List<CompletedReservation>>> GetCompletedReservationByUserId(int userId);
    }
}
