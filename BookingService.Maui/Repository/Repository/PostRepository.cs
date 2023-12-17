using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Post;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.ApiResponse.Post;
using BookingService.Maui.Repository.Interface;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BookingService.Maui.Repository.Repository
{
    public class PostRepository : BaseRepository, IPostRepository
    {
        public async Task<ResultModel<BaseCommandResponse>> AddPost(AddPostRequest model)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.PostAsJsonAsync("Post", model);
                if (response == null) return new ResultModel<BaseCommandResponse>(false, "Błąd połączenia z api", new BaseCommandResponse());

                var responseData = await response.Content.ReadAsStringAsync();
                BaseCommandResponse? registeryResponse = JsonConvert.DeserializeObject<BaseCommandResponse>(responseData);

                if (registeryResponse == null)
                    return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());

                if (response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
                    return new ResultModel<BaseCommandResponse>(false, registeryResponse.Message ?? string.Empty, registeryResponse);

                return new ResultModel<BaseCommandResponse>(true, "Pomyślnie dodano post", registeryResponse);
            }
            catch
            {
                return new ResultModel<BaseCommandResponse>(false, "Błąd wewnętrzny", new BaseCommandResponse());
            }
        }

        public async Task<ResultModel<List<PostViewModel>>> GetPosts()
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("Post");
                if (response == null) return new ResultModel<List<PostViewModel>>(false, "Błąd połączenia z api",
                    new List<PostViewModel>());

                var responseData = await response.Content.ReadAsStringAsync();
                List<PostViewModel>? servicesResponse = JsonConvert.DeserializeObject<List<PostViewModel>>(responseData);

                if (servicesResponse == null)
                    return new ResultModel<List<PostViewModel>>(false, "Błąd wewnętrzny", new List<PostViewModel>());

                return new ResultModel<List<PostViewModel>>(true, servicesResponse);
            }
            catch
            {
                return new ResultModel<List<PostViewModel>>(false, "Błąd wewnętrzny", new List<PostViewModel>());
            }
        }
    }
}
