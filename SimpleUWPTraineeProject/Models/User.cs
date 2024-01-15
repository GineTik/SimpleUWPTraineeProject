using Windows.Media.Effects;

namespace SimpleUWPTraineeProject.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public User Clone()
        {
            return new User
            { 
                FirstName = FirstName,
                SecondName = SecondName
            };
        }

        public override string ToString()
        {
            return FirstName + " " + SecondName;
        }
    }
}
