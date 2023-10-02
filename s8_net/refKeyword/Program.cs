
int number = 5;
int otherNumber = 15;
AddOneToNumber(ref number);

Console.WriteLine("Number now is: " + number);
MethodWithOutParameter(out otherNumber);
Console.WriteLine("Number now is: " + otherNumber);

Console.ReadKey();

void MethodWithOutParameter(out int number)
{
    number = 10;
}

void AddOneToNumber(ref int number)
{
    ++number;
}
