
public class GameDataParserApp
{
    private readonly IUserInteractor _userInteractor;
    private readonly IGamesPrinter _gamesPrinter;
    private readonly IVideoGameDeserializer _videoGameDeserializer;
    private readonly IFileReader _fileReader;

    public GameDataParserApp(IUserInteractor userInteractor, IGamesPrinter gamesPrinter, IVideoGameDeserializer videoGameDeserializer, IFileReader fileReader)
    {
        _userInteractor = userInteractor;
        _gamesPrinter = gamesPrinter;
        _videoGameDeserializer = videoGameDeserializer;
        _fileReader = fileReader;
    }

    public void Run()
    {
        string fileName = _userInteractor.ReadValidFilePath();

        var fileContent = _fileReader.Read(fileName);
        List<VideoGame> videoGames = _videoGameDeserializer.DesirializeFrom(fileName, fileContent);

        _gamesPrinter.Print(videoGames);
    }
}
