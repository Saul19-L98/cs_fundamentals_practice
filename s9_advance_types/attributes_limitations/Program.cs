Console.ReadKey();

[Some(new int[] { 1,2,3})]
public class SomeClass
{

}

public class SomeAttribute : Attribute
{
    public int[] Numbers { get; }
    public SomeAttribute(int[] numbers) 
    {
        Numbers = numbers;
    }
}