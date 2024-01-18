using Windows.Media.Effects;
using SimpleUWPTraineeProject.ViewModels.Base;

namespace SimpleUWPTraineeProject.Models
{
    public class User : BaseViewModel
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

        public User Clone()
        {
            return new User
            { 
                FirstName = FirstName,
                SecondName = SecondName
            };
        }

        public void ClearProperties()
        {
            FirstName = "";
            SecondName = "";
        }

        public void EditBy(User user)
        {
            FirstName = user.FirstName;
            SecondName = user.SecondName;
        }

        public override string ToString()
        {
            return FirstName + " " + SecondName;
        }
    }
}
