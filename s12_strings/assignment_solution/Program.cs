using assignment_solution.TicketsAggregation;

const string TicketsFolder = @"C:\Users\salla\OneDrive\Desktop\Tickets";

try
{
    var ticketAggregator = new TicketsAggregator(TicketsFolder, new FileWriter(), new DocumentsFromPdfReader());
    ticketAggregator.Run();
}
catch (Exception ex)
{
    Console.WriteLine("An exception occurred. " + "Exception message: " + ex.Message);
}

Console.ReadKey();
