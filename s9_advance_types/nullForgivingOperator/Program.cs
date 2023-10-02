
Console.ReadKey();

public class OddClass
{
    public string? Text { get; private set; }
    private bool _isInitialized;
    public void Init(string text)
    {
        Text = text;
        _isInitialized = true;
    }
    public void DoWork()
    {
        if(!_isInitialized)
        {
            throw new InvalidOperationException($"The class is not initialized");
        }
        Console.WriteLine("The length of text is: " + Text!.Length);
    }
}