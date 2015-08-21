namespace HelpingMethods
{
    using System;

    public class Student
    {
        public Student(string firstName, string lastName, DateTime birthDate, string town, string comments = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Comments = comments;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Town { get; set; }

        public string Comments { get; set; }

        public bool IsOlderThan(Student other)
        {
            return this.BirthDate < other.BirthDate;
        }
    }

}