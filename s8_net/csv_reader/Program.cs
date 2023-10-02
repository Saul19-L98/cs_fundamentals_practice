const string path = @"C:\Users\salla\Downloads\sampleData.csv";
var data = new CsvReader().Read(path);

Console.ReadKey();

public class CsvReader
{
    public CsvData Read(string path)
    {
        using var streamReader = new StreamReader(path);
        const string Separator = ";";
        var columns = streamReader.ReadLine().Split(Separator);
        var rows = new List<string[]>();
        while (!streamReader.EndOfStream)
        {
            var cellsInRow = streamReader.ReadLine().Split(Separator);
            rows.Add(cellsInRow);
        }
        return new CsvData(columns, rows);
    }
}

public class CsvData
{
    public string[] Columns { get; }
    public IEnumerable<string[]> Rows { get; }
    public CsvData(string[] columns,IEnumerable<string[]> rows)
    {
        Columns = columns;
        Rows = rows;
    }
}