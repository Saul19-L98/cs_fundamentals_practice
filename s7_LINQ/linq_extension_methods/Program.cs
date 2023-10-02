var words = new List<string> { "a", "bb", "ccc", "dddd" };
var wordsLongerThan2Letters = words.Where(word => word.Length > 2);
var numbers = new int[] { 1, 2, 3, 4, 5, 6 };
var oddNumbers = numbers.Where(numbers => numbers % 2 == 1);

Console.ReadKey();


public class Exercise
{
    public static bool IsAnyWordWhiteSpace(List<string> words)
    {
        var AllWordsAreEmpty = words.All(word => !string.IsNullOrWhiteSpace(word));
        if (AllWordsAreEmpty)
        {
            return false;
        }
        var result = words.Any(word =>
        {
            int wordLength = word.Length;
            int counter = 0;
            foreach (var letter in word)
            {
                if (char.IsWhiteSpace(letter))
                {
                    counter++;
                }
            }
            if (wordLength == counter)
            {
                return true;
            }
            return false;
        });
        return result;
    }

}