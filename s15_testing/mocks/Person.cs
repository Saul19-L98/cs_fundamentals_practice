namespace mocks
{
    public class Person
    {
        public int Id;
        public string? FirstName;
        public string? LastName;

        public Person(int personID, string? firstName, string? lastName)
        {
            this.Id = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}