var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };

var filteringStretegySalector = new FilteringStrategySelector();

Console.WriteLine("Select filter:");
Console.WriteLine(string.Join(Environment.NewLine,filteringStretegySalector.FilteringStrategiesNames));

var userInput = Console.ReadLine();

var filteringStrategy = new FilteringStrategySelector().Select(userInput);
var result = new Filter().FilterBy(filteringStrategy, numbers);

Print(result);

var words = new[] { "zebra", "ostrich", "otter" };
var oWords = new Filter().FilterBy(word => word.StartsWith("o"), words);

Console.ReadKey();

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(",", numbers));
}

public class FilteringStrategySelector
{
    private readonly Dictionary<string, Func<int, bool>> _filteringStrategies = new()
    {
        ["Even"] = n => n % 2 == 0,
        ["Odd"] = n => n % 2 == 1,
        ["Positive"] = n => n > 0,
        ["Negative"] = n => n < 0,
    };
    public IEnumerable<string> FilteringStrategiesNames => _filteringStrategies.Keys;
    public Func<int, bool> Select(string filteringType)
    {
        return _filteringStrategies[filteringType];
    }
}

public class Filter
{
    public IEnumerable<T> FilterBy<T>(Func<T,bool> predicate, IEnumerable<T> numbers)
    {
        var result = new List<T>();
        foreach (var number in numbers)
        {
            if (predicate(number))
            {
                result.Add(number);
            }
        }
        return result;
    }

}

