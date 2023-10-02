using System.Text.RegularExpressions;

public static class DataProperties
{
    public static MatchCollection GetStringsCollection(string pattern, string input)
    {
        return Regex.Matches(input, pattern);
    }
    public static string? GetString(string pattern, string input)
    {
        Match match = Regex.Match(input, pattern);
        if (match.Success)
        {
            return match.Groups[1].Value.Trim();
        }
        return null;
    }
}
