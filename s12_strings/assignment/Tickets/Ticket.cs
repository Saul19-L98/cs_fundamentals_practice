public class Ticket : ITicket
{
    private string? _title { get; init; }
    private DateTime? _date { get; init; }

    private DateTime? _time { get; init; }
    public Ticket(string? title, DateTime? date, DateTime? time)
    {
        _title = title;
        _date = date;
        _time = time;
    }
    public override string ToString()
    {
        return String.Format("{0},{1:dd/MM/yyyy},{2:HH:mm}", _title, _date, _time);
    }
}
