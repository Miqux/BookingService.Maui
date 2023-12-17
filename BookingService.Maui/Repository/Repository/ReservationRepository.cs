using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Reservation;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.ApiResponse.Reservation;
using BookingService.Maui.Repository.Interface;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BookingService.Maui.Repository.Repository
{
    public class ReservationRepository : BaseRepository, IReservationRepository
    {
        public async Task<ResultModel<BaseCommandResponse>> AddReservation(AddReservationRequest model)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Reservation", model);
                if (response == null) return new ResultModel<BaseCommandResponse>(false, "Błąd połączenia z api", new BaseCommandResponse());

                var responseData = await response.Content.ReadAsStringAsync();
                BaseCommandResponse? registeryResponse = JsonConvert.DeserializeObject<BaseCommandResponse>(responseData);

                if (registeryResponse == null)
                    return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());

                if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
                    return new ResultModel<BaseCommandResponse>(false, registeryResponse.Message ?? string.Empty, registeryResponse);

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return new ResultModel<BaseCommandResponse>(false, registeryResponse.Message ?? string.Empty, registeryResponse);

                return new ResultModel<BaseCommandResponse>(true, "Pomyślnie dodano usługę", registeryResponse);
            }
            catch
            {
                return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());
            }
        }

        public async Task<ResultModel<BaseCommandResponse>> DeleteReservation(int id)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.DeleteAsync("Reservation/" + id.ToString());
                if (response == null) return new ResultModel<BaseCommandResponse>(false, "Błąd połączenia z api", new BaseCommandResponse());

                var responseData = await response.Content.ReadAsStringAsync();
                BaseCommandResponse? deleteResponse = JsonConvert.DeserializeObject<BaseCommandResponse>(responseData);

                if (deleteResponse == null)
                    return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return new ResultModel<BaseCommandResponse>(false, deleteResponse.Message ?? string.Empty, deleteResponse);

                if (!response.IsSuccessStatusCode)
                    return new ResultModel<BaseCommandResponse>(false, deleteResponse.Message ?? string.Empty, deleteResponse);

                return new ResultModel<BaseCommandResponse>(true, "Pomyślnie usunięto rezerwacje", deleteResponse);
            }
            catch
            {
                return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());
            }
        }

        public async Task<ResultModel<List<CompletedReservationViewModel>>> GetCompletedReservationByUserId(int userId)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("Reservation/GetCompletedReservationsByUserId/" + userId.ToString());
                if (response == null) return new ResultModel<List<CompletedReservationViewModel>>(false, "Błąd połączenia z api",
                    new List<CompletedReservationViewModel>());

                var responseData = await response.Content.ReadAsStringAsync();
                List<CompletedReservationViewModel>? incomingReservationResponse = JsonConvert.DeserializeObject<List<CompletedReservationViewModel>>(responseData);

                if (incomingReservationResponse == null)
                    return new ResultModel<List<CompletedReservationViewModel>>(false, "Błąd wewnętrzny", new List<CompletedReservationViewModel>());

                return new ResultModel<List<CompletedReservationViewModel>>(true, incomingReservationResponse);
            }
            catch
            {
                return new ResultModel<List<CompletedReservationViewModel>>(false, "Błąd wewnętrzny", new List<CompletedReservationViewModel>());
            }
        }

        public async Task<ResultModel<List<IncomingReservationViewModel>>> GetIncomingReservationByUserId(int userId)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("Reservation/GetIncomingReservationsByUserId/" + userId.ToString());
                if (response == null) return new ResultModel<List<IncomingReservationViewModel>>(false, "Błąd połączenia z api",
                    new List<IncomingReservationViewModel>());

                var responseData = await response.Content.ReadAsStringAsync();
                List<IncomingReservationViewModel>? incomingReservationResponse = JsonConvert.DeserializeObject<List<IncomingReservationViewModel>>(responseData);

                if (incomingReservationResponse == null)
                    return new ResultModel<List<IncomingReservationViewModel>>(false, "Błąd wewnętrzny", new List<IncomingReservationViewModel>());

                return new ResultModel<List<IncomingReservationViewModel>>(true, incomingReservationResponse);
            }
            catch
            {
                return new ResultModel<List<IncomingReservationViewModel>>(false, "Błąd wewnętrzny", new List<IncomingReservationViewModel>());
            }
        }
    }
}
