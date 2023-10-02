var hashSet = new HashSet<string>();
hashSet.Add("aaa");
hashSet.Add("aaa");
hashSet.Add("bbb");
var hashSet2 = new SpellChcker();
hashSet2.PrintItems();

Console.ReadKey();

public class SpellChcker
{ 
    private readonly HashSet<string> _correctWords = new()
    {
        "dog","cat","fish"
    };
    public bool IsCorrect(string word) => _correctWords.Contains(word);
    public void AddCorrectWord(string word) => _correctWords.Add(word);
    public void PrintItems()
    {
        foreach (string word in _correctWords)
        {
            Console.WriteLine(word);
        }
    }
}

public static class HashSetsUnionExercise
{
    public static HashSet<T> CreateUnion<T>(
        HashSet<T> set1, HashSet<T> set2)
    {
        var listToHash = new List<T>();
        foreach (var items in set1)
        {
            listToHash.Add(items);
        }
        foreach (var items in set2)
        {
            listToHash.Add(items);
        }
        var resultHashSet = new HashSet<T>(listToHash);
        return resultHashSet;
    }
}