using System.Text.RegularExpressions;

public class TicketsCollection : ITicketsCollection
{
    private string _ticketInOneString = "";
    private List<Ticket> Tickets { get; init; }
    public TicketsCollection()
    {
        Tickets = new List<Ticket>();
    }
    private string[] GetSubstrings()
    {
        Regex regex = new Regex(@"tickets:(.*?)\bVisit\b");
        return regex.Split(_ticketInOneString);
    }
    private MatchCollection ticketsStringsCollection()
    {
        string ticketsPattern = @"Title:[^\r\n]*?(?=Title|$)";
        return DataProperties.GetStringsCollection(ticketsPattern, GetSubstrings()[1]);
    }
    private void AddTicketToCollection(string title, string? dateFound, string? timeFound)
    {
        if (dateFound is null || timeFound is null)
        {
            throw new ArgumentNullException("The string provided has none of date or time data.");
        }

        var date = DataFormatting.GetDate(dateFound);
        var time = DataFormatting.GetTime(timeFound);

        Ticket ticket = new Ticket(title, date, time);
        Tickets.Add(ticket);
    }
    public void AddToCollection(string ticketInOneString)
    {
        _ticketInOneString = ticketInOneString;
        string titlePattern = @"Title:\s*(.*?)\s*Date:";
        string datePattern = @"Date:\s*(.*?)\s*Time:";
        string timePattern = @"Time:(.*?)$";

        foreach (Match match in ticketsStringsCollection())
        {
            string capturedText = match.Value.Trim();
            var title = DataProperties.GetString(titlePattern, capturedText);
            var dateFound = DataProperties.GetString(datePattern, capturedText);
            var timeFound = DataProperties.GetString(timePattern, capturedText);
            AddTicketToCollection(title!, dateFound, timeFound);
        }

    }
    public void SingleTicketStringAddToCollection(string ticketInOneString)
    {
        _ticketInOneString = ticketInOneString;
        Regex regex = new Regex(",");
        string[] substring = regex.Split(ticketInOneString);
        var title = substring[0];
        var dateFound = substring[1];
        var timeFound = substring[2];
        AddTicketToCollection(title, dateFound, timeFound);
    }
    public List<Ticket> GetTicketsCollection()
    {
        return Tickets;
    }
}
