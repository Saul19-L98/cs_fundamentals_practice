var point1 = new Point(1, 5);
var point2 = new Point(2, 4);
//var added = point1.Add(point2);
var added = point1 + point2;
Console.WriteLine("point1 == point2 " + (point1 == point2));
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
        /*    return obj is Point point && X == point.X && Y == point.Y*/
        ;
        return obj is Point point && Equals(point);
    }
    public override string ToString() => $"X: {X}, Y: {Y}";

    public static bool operator ==(Point point1, Point point2) => point1.Equals(point2);

    public static bool operator !=(Point point1, Point point2) => !point1.Equals(point2);

    public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
}