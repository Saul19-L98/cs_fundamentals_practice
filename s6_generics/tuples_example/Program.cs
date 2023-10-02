var numbers = new List<int> { 5, 3, 2, 8, 16, 7 };
SimpleTuple<int, int> minAndMax = GetMinAndMax(numbers);
Console.WriteLine("Smallest number is " + minAndMax.Item1);
Console.WriteLine("Largest number is " + minAndMax.Item2);

var twoStrings = new SimpleTuple<string, string> ("aaa", "bbb" );
var differentTypes = new SimpleTuple<string, int>("aaa", 23);

var threeItems = new Tuple<string, int, bool>("aaa", 25, true);

Console.ReadKey();

SimpleTuple<int,int> GetMinAndMax(IEnumerable<int> input)
{
    if (!input.Any())
    {
        throw new InvalidOperationException($"The input collection cannot be empty.");
    }
    // "First" comes from LINQ. 📜
    int min = input.First();
    int max = input.First();
    foreach(var number in input)
    {
        if (number > max)
        {
            max = number;
        }
        if (number < min)
        {
            min = number;
        }
    }
    return new SimpleTuple<int,int>(min, max);
}

public class TwoInts
{
    public int Int1 { get; }
    public int Int2 { get; }
    public TwoInts(int int1, int int2)
    {
        Int1 = int1;
        Int2 = int2;
    } 
}

//172: Tuples
public class SimpleTuple<T1,T2>
{
    public T1 Item1 { get; }
    public T2 Item2 { get; }
    public SimpleTuple(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }
}