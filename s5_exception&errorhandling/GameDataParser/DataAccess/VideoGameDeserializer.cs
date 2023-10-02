using System.Text.Json;

public class VideoGameDeserializer : IVideoGameDeserializer
{
    private readonly IUserInteractor _userInteractor;

    public VideoGameDeserializer(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public List<VideoGame> DesirializeFrom(string fileName, string fileContent)
    {
        try
        {
            return JsonSerializer.Deserialize<List<VideoGame>>(fileContent);
        }
        catch (JsonException ex)
        {
            _userInteractor.PrintError($"JSON in {fileName} file was not in a valid format. JSON body:");
            _userInteractor.PrintError(fileContent);
            throw new JsonException($"{ex.Message} The file is: {fileContent}", ex);
        }
    }
}
