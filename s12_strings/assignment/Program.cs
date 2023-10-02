using assignment.DataAccess;
using assignment.FileAccess;

const string baseUrl = @"C:\Users\salla\OneDrive\Desktop\Tickets\";
const string fileStored = "tickets";
const FileFormat Format = FileFormat.Txt;
try
{
    var fileMetadata = new FileMetadata(fileStored, Format);

    IStringsRepository stringsRepository = new StringsTextualRepository();

    var stringTicketsCollection = new DirectoryInformation(baseUrl).ReadPdfFiles();

    var ticketsCollection = new TicketsCollection();

    var mainProgram = new PdfReaderApp(new TicketsRepository(stringsRepository, ticketsCollection), stringTicketsCollection, ticketsCollection);

    mainProgram.Run(fileMetadata.ToPath());
}
catch (Exception ex)
{
    throw new Exception("Something when wrong.", ex);
}

Console.ReadKey();
