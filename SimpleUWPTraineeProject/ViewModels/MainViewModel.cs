using SimpleUWPTraineeProject.Models;
using SimpleUWPTraineeProject.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace SimpleUWPTraineeProject.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public User NewUser { get; set; }

        public ObservableCollection<User> Users { get; set; }

        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand RemoveUserCommand { get; set; }

        public MainViewModel()
        {
            NewUser = new User();
            Users = new ObservableCollection<User>();
            AddUserCommand = new RelayCommand(AddUser);
            RemoveUserCommand = new RelayCommand(RemoveUser);
        }

        public void AddUser(object _)
        {
            Users.Add(NewUser.Clone());
        }

        public async void RemoveUser(object user)
        {
            if (user == null)
                return;

            var deleteFileDialog = new ContentDialog
            {
                Title = "Підтвердіть видалення",
                Content = $"Ви впевнені, що хочете видалити користувача \"{user}\"?",
                PrimaryButtonText = "Видалити",
                CloseButtonText = "Відмінити"
            };

            var result = await deleteFileDialog.ShowAsync();
            if (result != ContentDialogResult.Primary)
                return;

            Users.Remove((User)user);
        }
    }
}
