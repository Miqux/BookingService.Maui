using BookingService.Maui.Model.User;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BookingService.Maui.ViewModel.Administration
{
    public partial class UsersViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<UserAdministration>? userList;

        [ObservableProperty]
        UserAdministration? selectedUser;
        public UsersViewModel()
        {

        }

        [RelayCommand]
        public async Task Appearing()
        {
            IsBusy = true;
            var users = await AuthService.GetUserAdministration();
            if (users.Result)
                UserList = new ObservableCollection<UserAdministration>(users.Value);
            IsBusy = false;
        }

        [RelayCommand]
        private async Task ItemSelected()
        {
            if (SelectedUser is null)
                return;

            List<string> options = new()
            {
                "Dodaj rolę właściciela firmy"
            };

            string selectedOption = await DialogService.ShowOptionsDialog("Wybierz opcje", options);

            if (selectedOption == null)
                return;

            switch (selectedOption)
            {
                case "Dodaj rolę właściciela firmy":
                    {
                        await SetCompanyBossRole(SelectedUser);
                    }
                    break;
            }
        }
        private async Task SetCompanyBossRole(UserAdministration selectedUser)
        {
            IsBusy = true;
            var model = new UpdateUserRole()
            {
                Id = selectedUser.Id,
                Role = Model.Enums.UserRole.CompanyBoss
            };

            var result = await AuthService.UpdateUserRole(model);
            IsBusy = false;

            if (result.Result)
            {
                await DialogService.ShowAlert("Powodzenie", "Pomyśle zmieniono rolę użytkownika");
                return;
            }
            await DialogService.ShowAlert("Niepowodzenie", "Nie udało się zmienić roli użytkownika");
        }
    }
}
