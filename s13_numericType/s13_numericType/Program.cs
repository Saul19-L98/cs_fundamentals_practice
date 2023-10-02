
var twoBillion = 2_000_000_000;
int sumSoFar = 1_900_000_000;
int nextTransaction = 1_000_000_000;
long sumAfterTransaction = (long)sumSoFar + (long)nextTransaction;
//"checked" keyword defines a scope in which arithmetic operations will be checked for overflow.
//checked
//{
//    if (sumSoFar + nextTransaction > twoBillion)
//    {
//        Console.WriteLine("Transaction blocked.");
//    }
//    else
//    {
//        Console.WriteLine("Transaction executed.");
//    }
//}

if (sumAfterTransaction > twoBillion)
{
    Console.WriteLine("Transaction blocked.");
}
else
{
    Console.WriteLine("Transaction executed.");
}

Console.ReadKey();

public static class CheckedFibonacciExercise
{
    public static IEnumerable<int> GetFibonacci(int n)
    {
        int[] result = new int[n];
        checked
        {
            for (int i = 0; i < result.Length; i++)
            {
                if (i == 0)
                {
                    result[i] = i;
                }
                else if (i == 1)
                {
                    result[i] = i;
                }
                else
                {
                    result[i] = result[i - 1] + result[i - 2];
                }
            }
        }
        return result;
    }
}