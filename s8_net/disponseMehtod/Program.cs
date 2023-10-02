using System.IO;

const string filePath = "file.txt";
using var writer = new FileWriter(filePath);
writer.Write("some text");
writer.Write("some other text");
writer.Dispose();

using var reader = new SpecificLineFromTextFileReader(filePath);
var third = reader.ReadLineNumber(3);
var fourth = reader.ReadLineNumber(4);
reader.Dispose();

Console.WriteLine("Third line is: " + third);
Console.WriteLine("Fourth line is: " + fourth);

Console.ReadKey();

public class FileWriter : IDisposable
{
    private readonly StreamWriter _streamWriter;
    public FileWriter(string filePath)
    {
        _streamWriter = new StreamWriter(filePath, true);
    }
    public void Write(string text)
    {
        _streamWriter.WriteLine(text);
        _streamWriter.Flush();
    }
    public void Dispose()
    {
        _streamWriter.Dispose();
    }
}

public class SpecificLineFromTextFileReader : IDisposable
{
    private readonly StreamReader _steamReader;

    public SpecificLineFromTextFileReader(string filePath)
    {
        _steamReader = new StreamReader(filePath);
    }
    public string ReadLineNumber(int lineNumber)
    {
        _steamReader.DiscardBufferedData();
        _steamReader.BaseStream.Seek(0,SeekOrigin.Begin);
        for (var i = 0; i < lineNumber - 1; ++i)
        {
            _steamReader.ReadLine();
        }
        return _steamReader.ReadLine();
    }
    public void Dispose()
    {
        _steamReader.Dispose();
    }
}