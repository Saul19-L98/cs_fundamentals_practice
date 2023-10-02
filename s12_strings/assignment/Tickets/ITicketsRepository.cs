namespace assignment.Tickets;

public interface ITicketsRepository
{
    List<Ticket> Read(string filePath);
    void Write(string filePath, List<Ticket> tickets);
}
