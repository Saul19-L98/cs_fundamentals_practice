using System.Text.Json;

public class AccessingFile
{
    private readonly string _jsonFilesDirectory;
    private string _filePath;

    public AccessingFile(string jsonFilesDirectory)
    {
        _jsonFilesDirectory = jsonFilesDirectory;
    }

    public void FilePath()
    {
        string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string jsonFolderPath = Path.Combine(rootDirectory, _jsonFilesDirectory);
        string value;
        string jsonFilePath;
        bool isValidInput = false;

        do
        {
            Console.WriteLine("Enter the name of the file you want to read:");
            value = Console.ReadLine();
            try
            {
                if (string.Equals(value,string.Empty))
                {
                    throw new ArgumentException("File name cannot be empty.");
                }
                if (string.Equals(value, null))
                {
                    throw new ArgumentException("File name cannot be null.");
                }
                jsonFilePath = Path.Combine(jsonFolderPath, value);
                if (!File.Exists(jsonFilePath))
                {
                    throw new FileNotFoundException("File does not exist");
                }
                _filePath = jsonFilePath;
                isValidInput = true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorLogger.LogError(ex);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                ErrorLogger.LogError(ex);
            }
        } while (!isValidInput);
        
    }
    public void ReadFile()
    {
        JsonDocument jsonDocument;
        string jsonContent = File.ReadAllText(_filePath);
        string fileName = Path.GetFileName(_filePath);
        try
        {
            jsonDocument = JsonDocument.Parse(jsonContent);
            Console.WriteLine(jsonDocument);
            JsonElement root = jsonDocument.RootElement;
            PrintingToConsole.Print(root);
        }
        catch (JsonException ex)
        {
            PrintingToConsole.PrintInvalidFormat(jsonContent,fileName);
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
            ErrorLogger.LogError(ex);
        }
    }
}
