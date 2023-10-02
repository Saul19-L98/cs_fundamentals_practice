using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleTables;

var baseAddress = "https://swapi.dev/api/";
var requestUrl = "planets";
string[] columns = { "Name", "Diameter", "SurfaceWater", "Population" };
try
{
var startProgram = new MainProgram(baseAddress, requestUrl,new ApiDataReader(),new Table(columns));
await startProgram.Start();
}
catch (Exception ex)
{
    DisplayToConsole.Print($"Message: {ex.Message}");
}
DisplayToConsole.Print("Press any key to close.");
Console.ReadKey();

public interface IApiDataReader
{
    Task<string> Read(string baseAddress, string requestUrl);
}

public class ApiDataReader : IApiDataReader
{
    public async Task<string> Read(string baseAddress, string requestUrl)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage response = await client.GetAsync(requestUrl);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}

public interface IValues
{
    (Planet MaxDiameterPanet, Planet MinDiameterPlanet) DaimeterStatistic();
    (Planet MaxPopulationPlanet, Planet MinPopulationPlanet) PopulationStatistic();
    (Planet MaxSurfaceWaterPlanet, Planet MinSurfaceWaterPlanet) SurfaceWaterStatistic();
}

public struct Values : IValues
{
    private IReadOnlyList<Planet> _planets { get; }
    public Values(IReadOnlyList<Planet> planets)
    {
        _planets = planets;
    }
    private (Planet MaxValue, Planet MinValue) GetMaxMinValue(Func<Planet, string> propertySelector)
    {
        var validPlanets = _planets.Where(planet => propertySelector(planet) != "unknown");
        var max = validPlanets.OrderByDescending(planet => long.TryParse(propertySelector(planet), out long value) ? value : long.MinValue).First();
        var min = validPlanets.OrderBy(planet => long.TryParse(propertySelector(planet), out long value) ? value : long.MaxValue).First();
        return (max, min);
    }
    public (Planet MaxPopulationPlanet, Planet MinPopulationPlanet) PopulationStatistic()
    {
        return GetMaxMinValue(planet => planet.population);
    }
    public (Planet MaxDiameterPanet, Planet MinDiameterPlanet) DaimeterStatistic()
    {
        return GetMaxMinValue(planet => planet.diameter);
    }
    public (Planet MaxSurfaceWaterPlanet, Planet MinSurfaceWaterPlanet) SurfaceWaterStatistic()
    {
        return GetMaxMinValue(planet => planet.surface_water);
    }
}

public class Operations
{
    private IValues _values;
    public Operations(IValues values) 
    {
        _values = values;
    }
    public void mainLoop()
    {
        Console.WriteLine("Select the statistics you are interested in: ");
        string? input = Console.ReadLine();
        if (input == null)
        {
            Console.WriteLine("Not a valid statistic");
            return;
        }
        switch (input)
        {
            case "diameter":
                var daimeterStatistic = _values.DaimeterStatistic();
                DisplayToConsole.Print($"Max population is {daimeterStatistic.MaxDiameterPanet.diameter} (planet: {daimeterStatistic.MaxDiameterPanet.name})");
                DisplayToConsole.Print($"Min population is {daimeterStatistic.MinDiameterPlanet.diameter} (planet: {daimeterStatistic.MinDiameterPlanet.name})");
                break;
            case "surface water":
                var surfaceWaterStatistic = _values.SurfaceWaterStatistic();
                DisplayToConsole.Print($"Max surface of water is {surfaceWaterStatistic.MaxSurfaceWaterPlanet.surface_water} (planet: {surfaceWaterStatistic.MaxSurfaceWaterPlanet.name})");
                DisplayToConsole.Print($"Min surface of water is {surfaceWaterStatistic.MinSurfaceWaterPlanet.surface_water} (planet: {surfaceWaterStatistic.MinSurfaceWaterPlanet.name})");
                break;
            case "population":
                var populationStatistic = _values.PopulationStatistic();
                DisplayToConsole.Print($"Max population is {populationStatistic.MaxPopulationPlanet.population} (planet: {populationStatistic.MaxPopulationPlanet.name})");
                DisplayToConsole.Print($"Min population is {populationStatistic.MinPopulationPlanet.population} (planet: {populationStatistic.MinPopulationPlanet.name})");
                break;
            default:
                DisplayToConsole.Print("Invalid choice.");
                break;
        }
    }
}

public interface ITable
{
    void CreateConsoleTable(Root root);
}

public class Table : ITable
{
    private string[] _columns { get; }
    public Table(string[] columns)
    {
        _columns = columns;
    }
    public void CreateConsoleTable(Root root)
    {
        var table = new ConsoleTable(_columns);
        foreach (var planet in root.dataPlanets)
        {
            table.AddRow(planet.name, DisplayValidValue(planet.diameter), DisplayValidValue(planet.surface_water), DisplayValidValue(planet.population));
        }
        table.Write();
    }
    private string DisplayValidValue(string value)
    {
        return value == "unknown" ? "" : value;
    }
}

public class MainProgram
{
    private string _baseAddress;
    private string _requestUrl;
    private IApiDataReader _apiDataReader;
    private ITable _table;
    public MainProgram(string baseAddress,string requestUrl, IApiDataReader apiDataReader, ITable table)
    {
        _baseAddress = baseAddress;
        _requestUrl = requestUrl;
        _apiDataReader = apiDataReader;
        _table = table;
    }
    public async Task Start()
    {
        var json = await _apiDataReader.Read(_baseAddress, _requestUrl);
        var root = JsonSerializer.Deserialize<Root>(json);
        _table.CreateConsoleTable(root!);
        var startOperations = new Operations(new Values(root!.dataPlanets));
        startOperations.mainLoop();
    }
}

public static class DisplayToConsole
{
     public static void Print(string message)
    {
        Console.WriteLine(message);
    }
}

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public record Planet(
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("rotation_period")] string rotation_period,
    [property: JsonPropertyName("orbital_period")] string orbital_period,
    [property: JsonPropertyName("diameter")] string diameter,
    [property: JsonPropertyName("climate")] string climate,
    [property: JsonPropertyName("gravity")] string gravity,
    [property: JsonPropertyName("terrain")] string terrain,
    [property: JsonPropertyName("surface_water")] string surface_water,
    [property: JsonPropertyName("population")] string population,
    [property: JsonPropertyName("residents")] IReadOnlyList<string> residents,
    [property: JsonPropertyName("films")] IReadOnlyList<string> films,
    [property: JsonPropertyName("created")] DateTime created,
    [property: JsonPropertyName("edited")] DateTime edited,
    [property: JsonPropertyName("url")] string url
);

public record Root(
    [property: JsonPropertyName("count")] int count,
    [property: JsonPropertyName("next")] string next,
    [property: JsonPropertyName("previous")] object previous,
    [property: JsonPropertyName("results")] IReadOnlyList<Planet> dataPlanets
);