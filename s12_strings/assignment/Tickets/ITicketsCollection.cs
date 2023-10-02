public interface ITicketsCollection
{
    void AddToCollection(string ticketInOneString);
    void SingleTicketStringAddToCollection(string ticketInOneString);
    List<Ticket> GetTicketsCollection();
}
