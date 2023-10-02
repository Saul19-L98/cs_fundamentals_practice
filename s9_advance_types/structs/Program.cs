var point = new Point(1, 3);
var anotherPoint = point;
anotherPoint.Y = 100;


Console.WriteLine("point is: " + point);
Console.WriteLine("point is: " + anotherPoint);

Person person = new Person();

Console.ReadKey();

SomeMethod(5);
otherMethod(new Person());

void SomeMethod<T>(T param) where T : struct
{

}

void otherMethod<T>(T param) where T : class
{

}


struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public Point(int x, int y) 
    {
        X = x;
        Y = y;
    }
    public override string ToString() => $"X: {X}, Y: {Y}";
}

class Person
{
    private Point _favoritePoint;
    private Person _favoritePerson;
    public int Id { get; init; }
    public string Name { get; init; }
}

public struct Time
{
    public int Hour { get; }
    public int Minute { get; }
    public Time(int hour, int minute)
    {
        if ((hour < 0 || hour > 23) && minute > 59)
        {
            throw new ArgumentOutOfRangeException();
        }
        Hour = hour;
        Minute = minute;
    }
    public override string ToString() => $"{Hour.ToString("00")}:{Minute.ToString("00")}";
}