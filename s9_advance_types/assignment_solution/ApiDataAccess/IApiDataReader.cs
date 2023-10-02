namespace assignment_solution.ApiDataAccess;

public interface IApiDataReader
{
    Task<string> Read(string baseAddress, string requestUri);
}
