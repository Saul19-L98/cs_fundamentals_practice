using System.Globalization;

public static class DataFormatting
{
    public static DateTime GetDate(string date)
    {
        string[] formats = { "M/d/yyyy", "MM/dd/yyyy", "M/dd/yyyy", "MM/d/yyyy", "yyyy/MM/dd" };

        return DateTime.ParseExact(date, formats, CultureInfo.InvariantCulture);
    }
    public static DateTime GetTime(string time)
    {
        string[] formats = { "h:mm tt", "H:mm", "HH:mm" };

        return DateTime.ParseExact(time, formats, CultureInfo.InvariantCulture);
    }
}
