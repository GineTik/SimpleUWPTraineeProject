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
            NewUser.ClearProperties();
            OnPropertyChanged(nameof(NewUser));
        }

        public async void RemoveUser(object user)
        {
            var approvedOfRemovingUser = await ConfirmDialog.AskAsync(
                "Підтвердіть видалення", 
                $"Ви впевнені, що хочете видалити користувача \"{user}\"?", 
                "Видалити");

            if (user != null && approvedOfRemovingUser)
            {
                Users.Remove((User)user);
            }
        }
    }
}
