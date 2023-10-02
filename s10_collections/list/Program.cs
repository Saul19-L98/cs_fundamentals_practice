
using System.Diagnostics;

var input = Enumerable.Range(0, 100_000_000).ToArray();

Stopwatch stopwatch = Stopwatch.StartNew();
var list = new List<int>(input.Length);
foreach (var item in input)
{
    list.Add(item);
}
stopwatch.Stop();

Console.WriteLine($"Took: {stopwatch.ElapsedMilliseconds} ms");

list.Clear();
list.TrimExcess();
list.AddRange(input);

Console.ReadKey();