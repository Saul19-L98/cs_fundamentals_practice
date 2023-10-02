using System.Linq;

var stack = new Stack<string>();
stack.Push("a");
stack.Push("b");
stack.Push("c");

var top = stack.Pop();
var secondToTop = stack.Peek();

Console.ReadKey();

public static class StackExtensions
{
    public static bool DoesContainAny(this Stack<string> stack, params string[] input)
    {
        bool result = false;
        foreach (var word in input)
        {
            if (stack.Contains(word))
            {
                result = true;
            }
        }
        return result;
    }
}