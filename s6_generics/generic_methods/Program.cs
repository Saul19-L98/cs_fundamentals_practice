//var ints = new List<int> { 1,2,3};

var decimals = new List<decimal> { 1.1m, 0.5m, 22.5m, 12m };
//var inst = (List<int>)decimals;
var ints = decimals.ConvertTo<decimal,int>();

//ints.AddToFront(10);
//var myInput = new Tuple<string, decimal>("Sam",1.85m);
//var newInputs = myInput.SwapTupleItems();

Console.ReadKey();

//static class ListExtensions
//{
//    public static void AddToFront<T>(this List<T> list, T item)
//    {
//        list.Insert(0, item);
//    }
//}

//Class 175 Generic methods with multiple type parameters

static class ListExtensionsConvertion
{
    public static List<TTarget> ConvertTo<TSource,TTarget>(this List<TSource> input)
    {
        var result = new List<TTarget>();
        foreach(var item in input)
        {
            TTarget itemAfterCasting = (TTarget)Convert.ChangeType(item, typeof(TTarget));
            result.Add(itemAfterCasting);
        }
        return result;
    }
    public static void AddToFront<T>(this List<T> list, T item)
    {
        list.Insert(0, item);
    }

}

//  NOTE: this was test for some exercise.
//public static class TupleSwapExercise
//{
//    public static Tuple<TItem2, TItem1> SwapTupleItems<TItem1, TItem2>(this Tuple<TItem1,TItem2> input)
//    {
//        return new Tuple<TItem2, TItem1>(input.Item2, input.Item1);
//    }
//}