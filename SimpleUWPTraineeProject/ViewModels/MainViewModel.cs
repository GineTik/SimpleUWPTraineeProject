using System;
using SimpleUWPTraineeProject.Models;
using SimpleUWPTraineeProject.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace SimpleUWPTraineeProject.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _firstName;
        private string _secondName;
        private User _selectedUser;

        public string FirstName
        {
            get => _firstName;
            set => SetField(ref _firstName, value);
        }

        public string SecondName
        {
            get => _secondName;
            set => SetField(ref _secondName, value);
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set => SetField(ref _selectedUser, value);
        }

        public ObservableCollection<User> Users { get; set; }

        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand RemoveUserCommand { get; set; }

        public MainViewModel()
        {
            FirstName = "";
            SecondName = "";
            Users = new ObservableCollection<User>();
            AddUserCommand = new RelayCommand(AddUser);
            RemoveUserCommand = new RelayCommand(RemoveUser);
        }

        public void AddUser(object _)
        {
            Users.Add(new User
            {
                FirstName = FirstName,
                SecondName = SecondName
            });
        }

        public async void RemoveUser(object _)
        {
            if (SelectedUser == null)
                return;

            var deleteFileDialog = new ContentDialog
            {
                Title = "Підтвердіть видалення",
                Content = $"Ви впевнені, що хочете видалити користувача \"{SelectedUser}\"?",
                PrimaryButtonText = "Видалити",
                CloseButtonText = "Відмінити"
            };

            var result = await deleteFileDialog.ShowAsync();
            if (result != ContentDialogResult.Primary)
                return;

            Users.Remove(SelectedUser);
        }
    }
}
