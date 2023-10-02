using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;

public class DirectoryInformation : IDirectoryInformation
{
    private string _filesDirectoryUrl { get; }

    public DirectoryInformation(string filesDirectoryUrl)
    {
        _filesDirectoryUrl = filesDirectoryUrl;
    }
    private string[] FilesCollection() => Directory.GetFiles(_filesDirectoryUrl);
    private string TakeFileText(string file)
    {
        string extractedText = "";
        using (PdfDocument document = PdfDocument.Open(file))
        {
            foreach (Page page in document.GetPages())
            {
                var words = new string[page.GetWords().ToArray().Length];

                int count = 0;
                foreach (Word word in page.GetWords())
                {
                    words[count++] = word.Text;
                }

                extractedText = string.Join(" ", words);
            }
        }
        return extractedText;
    }
    public string[] ReadPdfFiles()
    {
        var files = FilesCollection();
        string[] strings = new string[files.Length];
        for (int i = 0; i < files.Length; i++)
        {
            strings[i] = TakeFileText(files[i]);
        }
        return strings;
    }
}
