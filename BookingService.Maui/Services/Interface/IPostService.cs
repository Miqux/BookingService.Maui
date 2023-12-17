using BookingService.Maui.Model;
using BookingService.Maui.Model.Post;

namespace BookingService.Maui.Services.Interface
{
    public interface IPostService
    {
        public Task<ResultModel<List<Post>>> Get();
        public Task<ResultModel<int?>> AddPost(Post model);
    }
}
