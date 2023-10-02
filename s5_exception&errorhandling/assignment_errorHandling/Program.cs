string jsonFilesDirectory = "JSON";
var startingApp = new AccessingFile(jsonFilesDirectory);
startingApp.FilePath();
startingApp.ReadFile();

Console.ReadKey();
