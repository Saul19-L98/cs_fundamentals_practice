var john = new Person(1, "John");
var theSameAsJohn = new Person(1, "John");
var marie = new Person(1, "Marie");
Console.WriteLine("john.Equals(theSameAsJohn) " + john.Equals(theSameAsJohn));
Console.WriteLine("john.Equals(marie): " + john.Equals(marie));
Console.WriteLine("john.Equals(null): " + john.Equals(null));

Console.ReadKey();

class Person
{
    public int Id { get; init; }
    public string Name { get; init; }
    public Person(int id, string name) 
    {
        Id = id;
        Name = name;
    }
    public override bool Equals(object? obj)
    {
        return obj is Person other && Id == other.Id;
    }
}