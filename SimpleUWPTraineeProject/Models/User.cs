using SimpleUWPTraineeProject.ViewModels.Base;

namespace SimpleUWPTraineeProject.Models
{
    public class User : BaseViewModel
    {
        private string _firstName;
        private string _secondName;
        private User _preEditState;

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

        public bool IsEditing => _preEditState != null;

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

        public void StartEdit()
        {
            _preEditState = Clone();
            OnPropertyChanged(nameof(IsEditing));
        }

        public void ConfirmEdit()
        {
            _preEditState = null;
            OnPropertyChanged(nameof(IsEditing));
        }

        public void CancelEditing()
        {
            if (_preEditState != null)
            {
                FirstName = _preEditState.FirstName;
                SecondName = _preEditState.SecondName;

                _preEditState = null;
                OnPropertyChanged(nameof(IsEditing));
            }
        }

        public override string ToString()
        {
            return FirstName + " " + SecondName;
        }
    }
}
