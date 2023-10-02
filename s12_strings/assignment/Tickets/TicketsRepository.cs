using assignment.DataAccess;
using assignment.Tickets;

public class TicketsRepository : ITicketsRepository
{
    private readonly IStringsRepository _stringsRepository;
    private ITicketsCollection _ticketCollection;

    public TicketsRepository(
        IStringsRepository stringsRepository, ITicketsCollection ticketCollection)
    {
        _stringsRepository = stringsRepository;
        _ticketCollection = ticketCollection;
    }

    public List<Ticket> Read(string filePath)
    {
        var ticketsInStringCollection = _stringsRepository.Read(filePath).Select(ticket => ticket.ToString()).ToList();
        foreach (var ticketInStringCollection in ticketsInStringCollection)
        {
            _ticketCollection.SingleTicketStringAddToCollection(ticketInStringCollection);
        }
        return _ticketCollection.GetTicketsCollection();
    }

    public void Write(string filePath, List<Ticket> tickets)
    {
        var ticketsAsStrings = tickets.Select(ticket => ticket.ToString()).ToList();
        _stringsRepository.Write(filePath, ticketsAsStrings);
    }
}
