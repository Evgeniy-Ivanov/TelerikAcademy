public class People
{
    enum Gender { Male, Female };

    public class Man
    {
        public Gender Sex { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public void CreateMan(int personalNumber)
    {
        Man person = new Man();
        person.Age = personalNumber;
        if (personalNumber % 2 == 0)
        {
            person.Name = "Adam";
            person.Sex = Gender.Male;
        }
        else
        {
            person.Name = "Eve";
            person.Sex = Gender.Female;
        }
    }
}