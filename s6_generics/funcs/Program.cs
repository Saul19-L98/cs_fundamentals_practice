// int a = 5;
//var john = new Person("John", "Smith", 1981);

using System;

var numbers = new[] { 1, 4,8, 7, 19, 2 };
Console.WriteLine("IsAnyLargerThan10 " + IsAny(numbers,IsLargerThan10));
Console.WriteLine("IsAnyEven " + IsAny(numbers,IsEven));
Console.ReadKey();

bool IsAny(IEnumerable<int> numbers,Func<int,bool> predicate)
{
    foreach (var number in numbers)
    {
        if (predicate(number))
        {
            return true;
        }
    }
    return false;
}

bool IsLargerThan10(int number)
{
    return number > 10;
}

bool IsEven(int number)
{
    return number % 2 == 0;
}

//bool IsAnyLargerThan10(IEnumerable<int> numbers)
//{
//    foreach(var number in numbers)
//    {
//        if (number > 10)
//        {
//            return true;
//        }
//    }
//    return false;
//}

//bool IsAnyEven(IEnumerable<int> numbers)
//{
//    foreach (var number in numbers)
//    {
//        if (number % 2 == 0)
//        {
//            return true;
//        }
//    }
//    return false;
//}

//NOTE: Example for an exercise in the course
public class Exercise
{
    public void TestMethod()
    {
        Func<int, bool,double> someMethod1 = Method1;
        Func<DateTime> someMethod2 = Method2;
        Action<string, string> someMethod3 = Method3;
    }

    public double Method1(int a, bool b) => 0;
    public DateTime Method2() => default(DateTime);
    public void Method3(string a, string b) { }
}