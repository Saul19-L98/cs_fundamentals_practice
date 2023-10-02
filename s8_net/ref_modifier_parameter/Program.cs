int number = 5;
AddOneToNumber(ref number);
Console.WriteLine("Number now is: " + number);


Console.ReadKey();

void AddOneToNumber(ref int number)
{
    ++number;
}