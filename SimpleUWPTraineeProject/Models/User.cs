﻿namespace SimpleUWPTraineeProject.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public override string ToString()
        {
            return FirstName + " " + SecondName;
        }
    }
}
