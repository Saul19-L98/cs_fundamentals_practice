//var points = CreateCollectionOfRandomLength<Point>(100);
using System.Diagnostics;

Stopwatch stopwatch = Stopwatch.StartNew();
var ints = CreateCollectionOfRandomLength<int>(0);
stopwatch.Stop();
Console.WriteLine($"Execution took {stopwatch.ElapsedMilliseconds} ms.");

Console.ReadKey();

IEnumerable<T> CreateCollectionOfRandomLength<T>(int maxLength) where T : new()
{
    //var point = new Point(1,2);
    /*new Random().Next(maxLength + 1)*/
    var length = 100000000;
    var result = new List<T>(length);
    for (int i = 0; i<length;i++)
    {
        result.Add(new T());
    }
    return result;
}

//Examples
public class Point
{
    public int X { get; }
    public int Y { get; }
    public Point(int x, int y)
    {
        X = x; 
        Y = y;
    }
}
