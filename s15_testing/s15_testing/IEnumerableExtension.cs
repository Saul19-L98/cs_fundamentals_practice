using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("s15_testingTests")]

namespace s15_testing;

internal static class EnumerableExtensions
{
    public static int SumOfEvenNUmbers(this IEnumerable<int> numbers)
    {
        return numbers.Where(IsEven).Sum();
        //int sum = 0;
        //foreach (var number in numbers)
        //{
        //    if (number % 2 == 0)
        //    {
        //        sum += number;
        //    }
        //}
        //return sum;
    }
    private static bool IsEven(int number) => number % 2 == 0;
}
