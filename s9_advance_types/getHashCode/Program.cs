var dictionary = new Dictionary<Person, int>();
var martin = new Person(6, "Martin");
dictionary[martin] = 5;
var theSameAsMartin = new Person(6, "Martin");
Console.WriteLine(dictionary[theSameAsMartin]);
Console.ReadKey();

struct Point : IEquatable<Point>
{
    public int X { get; init; }
    public int Y { get; init; }
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public bool Equals(Point point)
    {
        return X == point.X && Y == point.Y;
    }
    public override bool Equals(Object? obj)
    {
        return obj is Point point && Equals(point);
    }
    public override string ToString() => $"X: {X}, Y: {Y}";

    public static bool operator ==(Point point1, Point point2) => point1.Equals(point2);

    public static bool operator !=(Point point1, Point point2) => !point1.Equals(point2);

    public static implicit operator Point(Tuple<int, int> tuple) => new Point(tuple.Item1, tuple.Item2);

    public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
}

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