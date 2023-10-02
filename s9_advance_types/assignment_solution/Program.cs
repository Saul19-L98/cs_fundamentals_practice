using assignment_solution.ApiDataAccess;
using assignment_solution.DTOs;
using System.Text.Json;

try
{
    await new StarWarsPlanetStatsApp(new PlanetsFromApiReader(new ApiDataReader(), new MockStarWarsApiDataReader()),new PlanetsStaticticsAnalyzer()).Run();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred. " + "Exception message: " + ex.Message);
}
Console.WriteLine("Press any kety to close.");
Console.ReadKey();

public class StarWarsPlanetStatsApp
{
    
    private readonly IPlanetsReader _planetsReader;
    private readonly IPlanetsStatisticsAnalyzer _planetsStatisticsAnalyzer;
    public StarWarsPlanetStatsApp(IPlanetsReader planetsReader, IPlanetsStatisticsAnalyzer planetsStatisticsAnalyzer)
    {
        _planetsReader = planetsReader;
        _planetsStatisticsAnalyzer = planetsStatisticsAnalyzer;
    }

    public async Task Run()
    {
        var planets = await _planetsReader.Read();
        foreach (var planet in planets)
        {
            Console.WriteLine(planet);
        }
        _planetsStatisticsAnalyzer.Analyze(planets);
    }
}

public interface IPlanetsStatisticsAnalyzer
{
    void Analyze(IEnumerable<Planet> planets);
}

public class PlanetsStaticticsAnalyzer : IPlanetsStatisticsAnalyzer
{
    public void Analyze(IEnumerable<Planet> planets)
    {
                var propertyNamesToSelectorMapping = new Dictionary<string, Func<Planet, object>>
        {
            ["population"] = planets => planets.Population!,
            ["diameter"] = planets => planets.Diameter!,
            ["surface water"] = planets => planets.SurfaceWater!
        };
        Console.WriteLine();
        Console.WriteLine("The statistics of which property would you " + "like to see?");
        Console.WriteLine(string.Join(Environment.NewLine, propertyNamesToSelectorMapping.Keys));
        var userChoice = Console.ReadLine();
        if (userChoice is null || !propertyNamesToSelectorMapping.ContainsKey(userChoice))
        {
            Console.WriteLine("Invalid choice.");
        }
        else
        {
            ShowStatistics(planets, userChoice, propertyNamesToSelectorMapping[userChoice]);
        }
    }
    private static void ShowStatistics<T>(IEnumerable<Planet> planets, string propertyName, Func<Planet, T> propertySalector)
    {
        ShowStatistics(
            "Max",
            planets.MaxBy(propertySalector), propertySalector,
            propertyName);
        ShowStatistics(
            "Min",
            planets.MinBy(propertySalector), propertySalector,
            propertyName);
    }

    private static void ShowStatistics<T>(string description, Planet selectedPlanet, Func<Planet, T> propertySalector, string propertyName)
    {
        Console.WriteLine($"{description} {propertyName} is: " + $"{propertySalector(selectedPlanet)} " + $"(planet: {selectedPlanet.Name})");
    }
}

public interface IPlanetsReader
{
    Task<IEnumerable<Planet>> Read();
}


public class PlanetsFromApiReader : IPlanetsReader
{
    private IApiDataReader _apiDataReader;
    private IApiDataReader _mockApiDataReader;
    public PlanetsFromApiReader(IApiDataReader apiDataReader, IApiDataReader mockApiDataReader)
    {
        _apiDataReader = apiDataReader;
        _mockApiDataReader = mockApiDataReader;
    }
    public async Task<IEnumerable<Planet>> Read()
    {
        string? json = null;
        try
        {
            json = await _apiDataReader.Read("https://swapi.dev", "api/planets");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("API request was unsuccessful." + "Switching to mock data." + "Exception message: " + ex.Message);
        }
        json ??= await _mockApiDataReader.Read("https://swapi.dev", "api/planets");
        var root = JsonSerializer.Deserialize<Root>(json);
        return ToPlanets(root);
    }
    private static IEnumerable<Planet> ToPlanets(Root? root)
    {
        if (root is null)
        {
            throw new ArgumentNullException(nameof(root));
        }
        return root.dataPlanets.Select(planetDto => (Planet)planetDto);
        //var planets = new List<Planet>();
        //foreach (var planetDto in root.dataPlanets)
        //{
        //    Planet planet = (Planet)planetDto;
        //    planets.Add(planet);
        //}
        //return planets;
    }
}

public readonly record struct Planet
{
    public string Name { get; }
    public int? Diameter { get; }
    public int? SurfaceWater { get; }
    public long? Population { get; }

    public Planet(string name, int? diameter, int? surfaceWater, long? population)
    {
        if (name is null)
        {
            throw new ArgumentException(nameof(name));
        }
        Name = name;
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population;
    }

    public static explicit operator Planet(Result planetDto)
    {
        var name = planetDto.name;
        int? diameter = planetDto.diameter.ToNullable<int>();
        long? population = planetDto.population.ToNullable<long>();
        int? surfaceWater = planetDto.surface_water.ToNullable<int>();
        return new Planet(name, diameter, surfaceWater, population);
    }

}

public static class StringExtensions
{
    public static T? ToNullable<T>(this string? input) where T : struct
    {
        if (typeof(T) == typeof(int))
        {
            return int.TryParse(input, out int intValue) ? (T)(object)intValue : null;
        }
        if (typeof(T) == typeof(long))
        {
            return long.TryParse(input, out long longValue) ? (T)(object) longValue : null;
        }
        return null;
    }
}

public interface IUserInteractor
{
    void ShowMessage(string message);
    string? ReadFromUser();
}
public class ConsoleUserInteractor : IUserInteractor
{
    public string? ReadFromUser()
    {
        return Console.ReadLine();
    }
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}