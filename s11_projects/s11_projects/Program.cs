using utilities;

var numbers = new int[] { 1, 2, 3, };
Console.WriteLine(numbers.AsString());

//InternalClass internalClass;
//new PublicClass.ProtectedInternal();

Console.WriteLine("Hello");
Console.ReadKey();

public class DerivedFromPublicClass : PublicClass
{
    public void Test()
    {
        ProtectedInternal();
    }
}