var sortedList = new List<int>
{
    1,3,4,5,6,11,12,14,16,18
};
var indexOf1 = sortedList.FindIndexInSorted(1);
var indexOf11 = sortedList.FindIndexInSorted(11);
var indexOf12 = sortedList.FindIndexInSorted(12);
var indexOf18 = sortedList.FindIndexInSorted(18);
var indexOf13 = sortedList.FindIndexInSorted(13);

Console.ReadKey();

public static  class ListExtensions
{
    //Binary search
    public static int? FindIndexInSorted<T>(this IList<T> list,T itemTOFind) where T : IComparable<T>
    {
        int leftBound = 0;
        int rightBound = list.Count - 1;
        while (leftBound <= rightBound)
        {
            int middleIndex = (leftBound + rightBound) / 2;
            if (itemTOFind.Equals(list[middleIndex]))
            {
                return middleIndex;
            }
            else if (itemTOFind.CompareTo(list[middleIndex]) < 0)
            {
                rightBound = middleIndex - 1;
            }
            else
            {
                leftBound = middleIndex + 1;
            }
        }
        return null;
    }
}