// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
using System.Collections;

var customCollection = new CustomCollection(new string[] { "aaa", "bbb", "ccc" });
//var enumerator = customCollection.GetEnumerator();
foreach (var word in customCollection)
{
Console.WriteLine(word);
}

var first = customCollection[0];
customCollection[1] = "abc";

var newCollection = new CustomCollection { "one", "two", "three" };

Console.ReadKey();

public class CustomCollection : IEnumerable<string>
{
    public string[] Words { get; }

    public CustomCollection(string[] words)
    {
        Words = words;
    }
    public string this[int index]
    {
        get => Words[index];
        set => Words[index] = value;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<string> GetEnumerator()
    {
        return new WordsEnumerator(Words);
    }
}

public class WordsEnumerator : IEnumerator<string>
{
    private const int InitialPosition = -1;
    private int _currentPosition = InitialPosition;
    private readonly string[] _words;

    public WordsEnumerator(string[] words)
    {
        _words = words;
    }
    object IEnumerator.Current => Current;
    public string Current
    {
        get
        {
            try
            {
                return _words[_currentPosition];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException($"{nameof(CustomCollection)}'s end reached.", ex);
            }
        }
    }

    public bool MoveNext()
    {
        ++_currentPosition;
        return _currentPosition < _words.Length;
    }

    public void Reset()
    {
        _currentPosition = InitialPosition;
    }
    public void Dispose() { }
}


//Example of an exercise from the course
public class PairOfArrays<TLeft, TRight>
{
    private readonly TLeft[] _left;
    private readonly TRight[] _right;

    public PairOfArrays(
        TLeft[] left, TRight[] right)
    {
        _left = left;
        _right = right;
    }

    public ValueTuple<TLeft, TRight> this[int indexLeft, int indexRight]
    {
        get
        {
            if (indexLeft >= _left.Length && indexRight >= _right.Length)
            {
                throw new IndexOutOfRangeException();
            }
            return (_left[indexLeft], _right[indexRight]);
        }
        set
        {
            _left[indexLeft] = value.Item1;
            _right[indexRight] = value.Item2;
        }
    }
}