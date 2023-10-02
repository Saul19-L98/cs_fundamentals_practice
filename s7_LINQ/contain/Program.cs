var numbers = new[] { 16, 8, 9, -1, 2 };
bool is7Persent = numbers.Contains(7);
Console.WriteLine($"{is7Persent},{nameof(is7Persent)}");

var words = new[] { "lion", "tiger", "snow leopard" };
bool isTigerPresent = words.Contains("tiger");
Console.WriteLine($"{isTigerPresent},{nameof(isTigerPresent)}");

Console.ReadKey();