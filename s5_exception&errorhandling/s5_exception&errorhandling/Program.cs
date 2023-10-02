Console.WriteLine("Enter a number:");
//string input = Console.ReadLine();
//try
//{
//    int number = ParseStringToInt(input);
//    int result = 10 / number;
//    Console.WriteLine($"10 / {number} is {result}");
//}
//catch (DivideByZeroException ex)
//{
//    Console.WriteLine("Division by zero is an invalid operation." + "Exception message: " + ex.Message);
//}
//catch(FormatException ex)
//{
//    Console.WriteLine("Wrong format. Input string is not parsable to int. " + "Exeception message: " + ex.Message);
//}
//catch(Exception ex)
//{
//    Console.WriteLine("Unexpected error occurred" + "Exception message: " + ex.Message);
//}
//finally
//{
//    Console.WriteLine("finally block is being executed.");
//}

//Console.ReadKey();

//int ParseStringToInt(string input)
//{
//    return int.Parse(input);
//}

//LECTION 141: Throwing exceptions explicitly
try
{
    //var result = GetFristElement(new int[0]);
    var result = IsFirstElementPositive(null);
}
catch(NullReferenceException ex)
{

}
Console.ReadKey();

int GetFristElement(IEnumerable<int> numbers)
{
    foreach (int number in numbers)
    {
        return number;
    }
    throw new InvalidOperationException("This collection cannot be empty.");
}

bool IsFirstElementPositive(IEnumerable<int> numbers)
{
    try
    {
        var firstElement = GetFristElement(numbers);
        return firstElement > 0;
    }
    catch(InvalidOperationException ex)
    {
        Console.WriteLine("The collection is empty!");
        return true;
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine("Sorry! The application experienced and unexpected error.");
        throw ex;
        //throw new ArgumentNullException("The collection is null.", ex);
    }
}

var numbers = new int[] { 1, 2, 3 };
var fourth = numbers[3];

public class Person
{
    public string Name { get;}
    public int YearOfBirth { get;}
    public Person(string name,int yaeroFBirth)
    {
        if (name is null)
        {
            throw new ArgumentNullException("Name is null!");
        }
        if(name == string.Empty)
        {
            throw new ArgumentException("Invalid name");
        }
        if (YearOfBirth < 1900 || YearOfBirth > DateTime.Now.Year)
        {
            throw new ArgumentOutOfRangeException("Invalid year of birth.");
        }
        Name = name;
        YearOfBirth = yaeroFBirth;
    }
}