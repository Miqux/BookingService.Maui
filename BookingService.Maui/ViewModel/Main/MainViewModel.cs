using BookingService.Maui.Model.Post;
using BookingService.Maui.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BookingService.Maui.ViewModel.Main
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Post>? postList;

        private readonly IPostService postService;

        public MainViewModel(IPostService postService)
        {
            this.postService = postService;
        }

        [RelayCommand]
        public async Task Appearing()
        {
            IsBusy = true;
            await InitalizeData();
            IsBusy = false;
        }
        public async Task InitalizeData()
        {
            var posts = await postService.Get();
            PostList = new ObservableCollection<Post>(posts.Value);
        }
    }
}
