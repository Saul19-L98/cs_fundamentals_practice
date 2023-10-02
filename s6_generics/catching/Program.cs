using System.Reflection.PortableExecutable;

var dataDownloader = new SlowDataDownloader();
var catching = new Catching<string>();

Console.WriteLine(catching.DownloadDataWithCache(id => dataDownloader.DownloadData(id), "id1"));
Console.WriteLine(catching.DownloadDataWithCache(id => dataDownloader.DownloadData(id), "id2"));
Console.WriteLine(catching.DownloadDataWithCache(id => dataDownloader.DownloadData(id), "id3"));
Console.WriteLine(catching.DownloadDataWithCache(id => dataDownloader.DownloadData(id), "id1"));
Console.WriteLine(catching.DownloadDataWithCache(id => dataDownloader.DownloadData(id), "id3"));
Console.WriteLine(catching.DownloadDataWithCache(id => dataDownloader.DownloadData(id), "id2")); 
Console.WriteLine(catching.DownloadDataWithCache(id => dataDownloader.DownloadData(id), "id1"));

Console.ReadKey();

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        //Let's imagine this method downloads  real data, and it does it slowly.
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}

public class Catching<T>
{
    private Dictionary<string, T> _dataChache;

    public Catching()
    {
        _dataChache = new Dictionary<string, T>();
    }

    public T DownloadDataWithCache(Func<string,T> dataDownloader, string id) 
    {
        if (!_dataChache.ContainsKey(id))
        {
            T data = dataDownloader(id);
            _dataChache[id] = data;
            return data;
        }
        else
        {
            return _dataChache[id];
        }
    }
}