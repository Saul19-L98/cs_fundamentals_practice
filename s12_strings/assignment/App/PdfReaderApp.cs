using assignment.Tickets;

public class PdfReaderApp
{
    private ITicketsRepository _ticketsRepository;
    private string[]? _stringTicketsCollection;
    private ITicketsCollection _ticketsCollection;
    public PdfReaderApp(ITicketsRepository ticketsRepository, string[]? stringTicketsCollection, ITicketsCollection ticketsCollection)
    {
        _ticketsRepository = ticketsRepository;
        _stringTicketsCollection = stringTicketsCollection;
        _ticketsCollection = ticketsCollection;
    }

    public void Run(string filePath)
    {
        foreach (var ticketText in _stringTicketsCollection!)
        {
            _ticketsCollection.AddToCollection(ticketText);
        }

        var tickets = _ticketsCollection.GetTicketsCollection();
        _ticketsRepository.Write(filePath, tickets);

        var readTickets = _ticketsRepository.Read(filePath);
        foreach (Ticket ticket in readTickets)
        {
            Console.WriteLine(ticket.ToString());
        }
    }
}