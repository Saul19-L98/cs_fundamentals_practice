var tuple = Tuple.Create(10, 20);
Point point = tuple;
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