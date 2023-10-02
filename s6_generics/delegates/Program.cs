ProcessString processString1 = TrimToLetters;
ProcessString processString2 = ToUpper;
Console.WriteLine(processString1("Helloooooooooooooooooooo"));
Console.WriteLine(processString2("Helloooooooooooooooooooo"));

Print print1 = text => Console.WriteLine(text.ToUpper());
Print print2 = text => Console.WriteLine(text.ToLower());
Print multipleCast = print1 + print2;
Print print4 = text => Console.WriteLine(text.Substring(0,3));
multipleCast += print4;
multipleCast("Crocodile");

Console.ReadKey();


string TrimToLetters(string input)
{
    return input.Substring(0, 5);
}

string ToUpper(string input)
{
    return input.ToUpper();
}

delegate string ProcessString(string input);

delegate void Print(string input);
 