using SimpleUWPTraineeProject.Models;
using SimpleUWPTraineeProject.ViewModels.Base;
using System;
using System.Collections.ObjectModel;

namespace SimpleUWPTraineeProject.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private User _editingUser;
        private User _editingUserCopy;

        public User NewUser { get; set; }
        public User EditingUserCopy
        {
            get => _editingUserCopy;
            set => SetField(ref _editingUserCopy, value);
        }

        public ObservableCollection<User> Users { get; set; }

        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand RemoveUserCommand { get; set; }
        public RelayCommand OpenEditingUserWindowCommand { get; set; }
        public RelayCommand EditUserCommand { get; set; }
        public RelayCommand CancelEditUserCommand { get; set; }

        public MainViewModel()
        {
            NewUser = new User();
            Users = new ObservableCollection<User>();
            AddUserCommand = new RelayCommand(AddUser);
            RemoveUserCommand = new RelayCommand(RemoveUser);
            OpenEditingUserWindowCommand = new RelayCommand(OpenEditingUserWindow);
            EditUserCommand = new RelayCommand(EditUser);
            CancelEditUserCommand = new RelayCommand(CancelEditUser);
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

        public void OpenEditingUserWindow(object user)
        {
            if (user != null)
            {
                _editingUser = (User)user;
                EditingUserCopy = _editingUser.Clone();
            }
        }

        public void EditUser(object _)
        {
            _editingUser.EditBy(EditingUserCopy);
            CloseEditingUserWindow();
        }

        public void CancelEditUser(object _)
        {
            CloseEditingUserWindow();
        }

        private void CloseEditingUserWindow()
        {
            _editingUser = null;
            EditingUserCopy = null;
        }
    }
}
