using System.Text.Json;

public static class PrintingToConsole
{
    public static void Print(JsonElement root)
    {
        Console.WriteLine("\n");
        Console.WriteLine("Games loaded are:");
        foreach (JsonElement gameElement in root.EnumerateArray())
        {
            string title = gameElement.GetProperty("title").GetString();
            double ranking = gameElement.GetProperty("ranking").GetDouble();
            int releaseYear = gameElement.GetProperty("release_year").GetInt32();
            Console.WriteLine($"{title}, released in {releaseYear}, Ranking: {ranking}");
        }
    }
    public static void PrintInvalidFormat(string message,string fileName)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"JSON in the {fileName} was not a valid format:");
        Console.WriteLine($"{message}");
        Console.ResetColor();
    }
}
