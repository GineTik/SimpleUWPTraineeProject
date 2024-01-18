using SimpleUWPTraineeProject.Models;
using SimpleUWPTraineeProject.ViewModels.Base;
using System;
using System.Collections.ObjectModel;

namespace SimpleUWPTraineeProject.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private User _editingUser;

        public User NewUser { get; set; }
        public User EditingUser
        {
            get => _editingUser;
            set => SetField(ref _editingUser, value);
        }

        public ObservableCollection<User> Users { get; set; }

        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand RemoveUserCommand { get; set; }
        public RelayCommand StartEditingUserCommand { get; set; }
        public RelayCommand ConfirmEditUserCommand { get; set; }
        public RelayCommand CancelEditingUserCommand { get; set; }

        public MainViewModel()
        {
            NewUser = new User();
            Users = new ObservableCollection<User>();
            AddUserCommand = new RelayCommand(AddUser);
            RemoveUserCommand = new RelayCommand(RemoveUser);
            StartEditingUserCommand = new RelayCommand(StartEditingUser);
            ConfirmEditUserCommand = new RelayCommand(ConfirmEditUser);
            CancelEditingUserCommand = new RelayCommand(CancelEditingUser);
        }

        public void AddUser(object _)
        {
            if (string.IsNullOrWhiteSpace(NewUser.FirstName) == false
                && string.IsNullOrWhiteSpace(NewUser.SecondName) == false)
            {
                Users.Add(NewUser.Clone());
                NewUser.ClearProperties();
            }
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

        public void StartEditingUser(object user)
        {
            if (user != null)
            {
                EditingUser?.CancelEditing();

                EditingUser = (User)user;
                EditingUser.StartEdit();
            }
        }

        public void ConfirmEditUser(object _)
        {
            EditingUser.ConfirmEdit();
        }

        public void CancelEditingUser(object _)
        {
            EditingUser.CancelEditing();
        }
    }
}
