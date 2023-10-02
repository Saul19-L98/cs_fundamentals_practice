var smallSubset = GenerateEvenNumbers();
//.Skip(5)
//.Take(10);
var firtThreeEvenNumbers = GenerateEvenNumbers().Take(3).ToList();

foreach (var evenNumber in firtThreeEvenNumbers)
{
    //if (number == 50)
    //{
    //    break;
    //}
    //Console.WriteLine(number);
    Console.WriteLine($"Number is {evenNumber}");
}
foreach (var evenNumber in firtThreeEvenNumbers)
{
    Console.WriteLine($"Number is {evenNumber}");
}

Console.ReadKey();

IEnumerable<int> GenerateEvenNumbers()
{
    for (int i = 0; i < int.MaxValue; i += 2)
    {
        Console.WriteLine($"Yielding {1}");
        yield return i;
    }
}