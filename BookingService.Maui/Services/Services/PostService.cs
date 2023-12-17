using AutoMapper;
using BookingService.Maui.Model;
using BookingService.Maui.Model.ApiRequest.Post;
using BookingService.Maui.Model.Post;
using BookingService.Maui.Repository.Interface;
using BookingService.Maui.Services.Interface;

namespace BookingService.Maui.Services.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper mapper;
        private readonly IPostRepository postRepository;

        public PostService(IMapper mapper, IPostRepository postRepository)
        {
            this.mapper = mapper;
            this.postRepository = postRepository;
        }
        public async Task<ResultModel<int?>> AddPost(Post model)
        {
            var addPostModel = mapper.Map<AddPostRequest>(model);
            var addPostResult = await postRepository.AddPost(addPostModel);

            if (!addPostResult.Result)
                return new ResultModel<int?>(false, addPostResult.Message, null);

            return new ResultModel<int?>(true, addPostResult.Value.Id);
        }

        public async Task<ResultModel<List<Post>>> Get()
        {
            var posts = await postRepository.GetPosts();

            if (!posts.Result || posts.Value is null)
                return new ResultModel<List<Post>>(false, posts.Message, new List<Post>());

            return new ResultModel<List<Post>>(true, mapper.Map<List<Post>>(posts.Value));
        }
    }
}
