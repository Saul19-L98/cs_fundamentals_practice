var numbers = new[] { 1, 4, 8, 7, 19, 2 };
Console.WriteLine("IsAnyLargerThan10 " + IsAny(numbers, n => n > 10));
Console.WriteLine("IsAnyEven " + IsAny(numbers, n => n % 2 == 0));
Console.ReadKey();

bool IsAny(IEnumerable<int> numbers, Func<int, bool> predicate)
{
    foreach (var number in numbers)
    {
        if (predicate(number))
        {
            return true;
        }
    }
    return false;
}

public class Exercise
{
    public Func<string, int> GetLength = n => n.Length;
    public Func<int> GetRandomNumberBetween1And10 = () => new Random().Next(0, 10);
    
}