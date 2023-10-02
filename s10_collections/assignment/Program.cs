using System.Collections;
using System.Collections.Generic;
LinkedList<int> linkedList = new LinkedList<int>
{
    1,
    2,
    3
};
linkedList.AddToFront(4);
linkedList.Remove(2);
int[] ints = new int[3];
 linkedList.CopyTo(ints,0);
Console.WriteLine(linkedList.Count());

Console.WriteLine("Linked List:");
foreach (int item in linkedList)
{
    Console.Write(item + " ");
}
Console.ReadKey();

public class LinkedListNode<T>
{
    public T Value { get; }
    public LinkedListNode<T>? Next { get; internal set; }
    public LinkedListNode(T value)
    {
        Value = value;
        Next = null;
    }   

}

public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnd(T item);
}

public class LinkedList<T> : ILinkedList<T>
{
    private LinkedListNode<T>? _head;

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        var newNode = new LinkedListNode<T>(item);
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            LinkedListNode<T>? current = _head;
            if (current.Next == null)
            {
                current.Next = newNode;
            }
            else
            {
                while (current != null)
                {
                    if (current.Next == null)
                    {
                        current.Next = newNode;
                        break;
                    }
                    current = current.Next;
                }
            }
        }
        Count++;
    }

    public void AddToEnd(T item)
    {
        Add(item);
    }

    public void AddToFront(T item)
    {
        var newNode = new LinkedListNode<T>(item);
        if (_head != null)
        {
            newNode.Next = _head;
            _head = newNode;
        }
        else
        {
            _head = newNode;
        }
        Count++;
    }

    public void Clear()
    {
        _head = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        LinkedListNode<T>? current = _head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item))
            {
                return true;
            }
            current = current.Next != null ?current.Next : null;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        LinkedListNode<T>? current = _head;
        while(current != null && arrayIndex < array.Length) 
        {
            array[arrayIndex] = current.Value;
            current = current.Next;
            ++arrayIndex;   
        }
    }
    public bool Remove(T item)
    {
        LinkedListNode<T>? current = _head;
        LinkedListNode<T>? previous = null;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item))
            {
                if (previous == null)
                {
                    _head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }
                Count--;
                return true;
            }
            previous = current;
            current = current.Next;
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        LinkedListNode<T>? current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}