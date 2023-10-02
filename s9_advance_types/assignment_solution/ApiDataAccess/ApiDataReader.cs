namespace assignment_solution.ApiDataAccess;
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
