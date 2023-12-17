using BookingService.Maui.Model.Post;
using BookingService.Maui.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Maui.ViewModel.Administration
{
    public partial class AddPostViewModel : BaseValidatorViewModel
    {

        [Required(ErrorMessage = "Tytuł jest wymagany!")]
        [MinLength(3, ErrorMessage = "Tytuł powinien zawierać conajmniej 3 znaki!")]
        [MaxLength(20, ErrorMessage = "Tytuł nie może zawierać więcej niż 20 znaków!")]
        [ObservableProperty]
        string title = string.Empty;

        [Required(ErrorMessage = "Treść jest wymagana!")]
        [MinLength(3, ErrorMessage = "Treść powinna zawierać conajmniej 3 znaki!")]
        [ObservableProperty]
        string content = string.Empty;

        private readonly IPostService postService;

        public AddPostViewModel(IPostService postService)
        {
            this.postService = postService;
        }

        [RelayCommand]
        public async Task AddPostButtonClick()
        {
            var validation = Validate();
            if (!validation.Item1)
            {
                await DialogService.ShowAlert("Niepoprawne dane", validation.Item2);
                return;
            }

            var post = new Post()
            {
                Title = Title,
                Content = Content
            };
            var result = await postService.AddPost(post);

            if (!result.Result)
            {
                await DialogService.ShowAlert("Niepowodzenie", "Nie udało się dodać postu");
                return;
            }
            await DialogService.ShowAlert("Powodzenie", "Dodano nowy post");
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
