using SimpleUWPTraineeProject.Models;
using SimpleUWPTraineeProject.ViewModels.Base;
using System.Collections.ObjectModel;

namespace SimpleUWPTraineeProject.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _firstName;
        private string _secondName;

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

        public ObservableCollection<User> Users { get; set; }

        public RelayCommand AddUserCommand { get; set; }

        public MainViewModel()
        {
            FirstName = "";
            SecondName = "";
            AddUserCommand = new RelayCommand(AddUser);
            Users = new ObservableCollection<User>();
        }

        public void AddUser(object _)
        {
            Users.Add(new User
            {
                FirstName = FirstName,
                SecondName = SecondName
            });
        }
    }
}
