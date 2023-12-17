using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Post;
using BookingService.Maui.Model.ApiResponse;
using BookingService.Maui.Model.ApiResponse.Post;

namespace BookingService.Maui.Repository.Interface
{
    public interface IPostRepository
    {
        public Task<ResultModel<List<PostViewModel>>> GetPosts();
        public Task<ResultModel<BaseCommandResponse>> AddPost(AddPostRequest model);
    }
}
