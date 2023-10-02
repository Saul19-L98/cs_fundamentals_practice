using firstAssignment;

int sequenceLength = 1;
var sequence = Fibonacci.Generate(sequenceLength);
Console.WriteLine(string.Join(", ",sequence));

Console.ReadKey();
