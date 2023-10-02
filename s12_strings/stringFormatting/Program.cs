using System.Globalization;

CultureInfo currentCulture = CultureInfo.CurrentCulture;
Console.WriteLine(currentCulture);

var number1 = 100;
var number2 = 200;

var text = string.Format("Number 1 is {0}, number 2 is {1}", number1,number2);

Console.WriteLine(text);

Console.ReadKey();