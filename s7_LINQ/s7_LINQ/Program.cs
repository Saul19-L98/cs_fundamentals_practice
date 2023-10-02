// Without Using LINQ
var wordsNoUpperCase = new string[]
{
    "quick","brown","fox"
};
Console.WriteLine(IsAnyWordUpperCase(wordsNoUpperCase));
var wordsWithUpperCase = new string[]
{
    "QUICK","BROWN","FOX"
};

Console.WriteLine(IsAnyWordUpperCase(wordsWithUpperCase));

Console.ReadKey();

bool IsAnyWordUpperCase(IEnumerable<string> words)
{
    foreach (var word in words)
    {
        bool areAllUpperCase = true;
        foreach (var letter in word)
        {
            if (char.IsLower(letter))
            {
                areAllUpperCase = false;
            }
        }
        if (areAllUpperCase)
        {
            return true;
        }
    }
    return false;
}

//With LINQ
bool IsAnyWordUpperCase_Linq(IEnumerable<string> words)
{
    return words.Any(word => word.All(letter => char.IsUpper(letter)));
}