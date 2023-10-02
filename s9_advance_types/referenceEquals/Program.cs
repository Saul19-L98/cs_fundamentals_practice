var john = new Person(1, "John");
var theSameAsJohn = new Person(1, "John");

Console.WriteLine("Are reference equal? " + object.ReferenceEquals(john, theSameAsJohn));

Console.ReadKey();

struct Point
{
    public int X { get; init; }
    public int Y { get; init; }
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Person
{
    public string Name { get; set; }
    public int Id { get; set; }
    public Person(int id, string name)
    {
        Id = id;
        Name = name;
    }
}