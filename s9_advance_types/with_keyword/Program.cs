var point = new Point(10,20);
var pointMoved = point with { X=5, Y=10 };

var pet = new { Name = "Luna", Type = "Cat" };
var anotherPet = pet with { Name = "Carlos", Type = "Dog" };

Console.ReadKey();

struct Point
{
    public int X { get; init; } 
    public int Y { get; init; }
    public Point(int x , int y)
    {
        X = x;
        Y = y;
    }
}