var numbers = new ListOf<int>();
numbers.Add(10);
numbers.Add(20);
numbers.Add(30);
numbers.Add(40);
numbers.Add(50);

var words = new ListOf<string>();
words.Add("aaa");
words.Add("bbb");
words.Add("ccc");
words.Add("ddd");
words.Add("bdedr");

var dates = new ListOf<DateTime>();
dates.Add(new DateTime(2023, 5, 11));
dates.Add(new DateTime(2023, 5, 12));

numbers.RemoveAt(2);

Console.ReadKey();

class ListOf<T>
{
    private T[] _items = new T[4];
    private int _size = 0;
    public void Add(T item)
    {
        if(_size >= _items.Length)
        {
            var newItems = new T[_items.Length * 2];
            for(int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }
        _items[_size] = item;
        ++_size;
    }
    public void RemoveAt(int index)
    {
        if(index < 0 || index >= _size) 
        { 
            throw new IndexOutOfRangeException($"Index {index} is outside the bounds of the list.");
        }
        --_size;
        for(int i = index; i < _size; ++i)
        {
            _items[i] = _items[i + 1];
        }
        _items[_size] = default;
    }
    public T GetAtIndex(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException($"Index {index} is outside the bounds of the list.");
        }
        return _items[index];
    }
}

class Pair<T>
{
    public T First { get; private set; }
    public T Second { get; private set; }
    public Pair(T first, T second)
    {
        First = first;
        Second = second;
    }
    public void ResetFirst()
    {
        First = default;
    }
    public void ResetSecond()
    {
        Second = default;
    }

}