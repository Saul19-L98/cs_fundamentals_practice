using System.Linq;

var listsOfNumbers = new List<List<int>>
{
    new List<int>{15,68,20,12,19,8,55},
    new List<int>{15,1,3,4,-19,8,7,6},
    new List<int>{5,-6,-2,-12,-10,7}
};

var result = listsOfNumbers.Select(listOfNumbers => new
{
    Count = listOfNumbers.Count(),
    Average = listOfNumbers.Average()
}).OrderByDescending(countAndAverage => countAndAverage.Average).Select(countAndAverage => $"Count is: {countAndAverage.Count}, Average is: {countAndAverage.Average}");


Console.WriteLine(string.Join(Environment.NewLine, result));

Console.ReadKey();

