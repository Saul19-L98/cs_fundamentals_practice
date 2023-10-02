Console.WriteLine(Calculator.Add(1,2));
Console.WriteLine(Calculator.Add(1, 2,3));
Console.WriteLine(Calculator.Add(1, 2, 3,4));
Console.WriteLine(Calculator.Add());

Console.ReadKey();

public static class Calculator
{
    public static int Add(params int[] numbers) => numbers.Sum();
}
