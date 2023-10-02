Console.WriteLine("Square of 2 is:" + Calculator.Square(2));
Console.WriteLine("Square of 4m is:" + Calculator.Square(4m));
Console.WriteLine("Square of 6d is:" + Calculator.Square(6d));
Console.ReadKey();

// Before .net 7
//public static class Calculator
//{
//    public static int Square(int input) => input * input;
//    public static decimal Square(decimal input) => input * input;
//    public static double Square(double input) => input * input;
//}

public static class Calculator
{
    public static int Square(int input) => input * input;
    public static decimal Square(decimal input) => input * input;
    public static double Square(double input) => input * input;
}



