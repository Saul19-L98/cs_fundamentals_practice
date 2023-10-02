var input = new[] { "a", "b", "a", "c", "d", "b" };
foreach (var item  in  Distict(input))
{
    Console.WriteLine(item);
}
//foreach (var number in GetSingleDigitNumbers())
//{
//    Console.WriteLine(number);
//}
Console.ReadKey();

//IEnumerable<int> GetSingleDigitNumbers()
//{
//    yield return 0;
//    yield return 1;
//    yield return 2;
//    yield return 3;
//    yield return 4;
//    yield return 5;
//    yield return 6;
//    yield return 7;
//    yield return 8;
//    yield return 9;
//}
IEnumerable<T> Distict<T>(IEnumerable<T> input)
{
    var hashSet = new HashSet<T>();
    foreach (var item in input)
    {
        if (!hashSet.Contains(item)) 
        {
            hashSet.Add(item);
            yield return item;
            Console.WriteLine("After yield");
        }
    }
}

IEnumerable<int> GetBeforeFirstNegative(IEnumerable<int> input)
{
    foreach (var number in input)
    {
        if (number >= 0)
        {
            yield return number;
        }
        else
        {
            yield break;
        }
    }
}
public class YieldExercise
{
    public static IEnumerable<T> GetAllAfterLastNullReversed<T>(IList<T> input)
    {
        for (int i = input.Count() - 1; i >= 0; i--)
        {
            if (input[i] != null)
            {
                yield return input[i];
            }
            else
            {
                yield break;
            }
        }
    }
}