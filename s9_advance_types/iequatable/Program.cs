var point1 = new Point(1, 5);
var point2 = new Point(1, 5);

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
    /*    return obj is Point point && X == point.X && Y == point.Y*/;
        return obj is Point point && Equals(point);
    }
    public override string ToString() => $"X: {X}, Y: {Y}";
}