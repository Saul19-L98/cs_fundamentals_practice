
public static class ErrorLogger
{
    private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.txt");

    public static void LogError(Exception ex)
    {
        using (StreamWriter writer = File.AppendText(LogFilePath))
        {
            writer.WriteLine($"[{DateTime.Now}] Error: {ex.Message}");
            writer.WriteLine($"StackTrace: {ex.StackTrace}");
            writer.WriteLine();
        }
    }
}