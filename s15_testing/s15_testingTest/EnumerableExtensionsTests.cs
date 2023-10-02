using NUnit.Framework;
using s15_testing;
namespace s15_testingTests;

public class EnumerableExtensionsTests
{
    [Test]
    public void SumOfEvenNUmbers_ShallReturnZero_FromEmptyCollection()
    {
        var input = Enumerable.Empty<int>();
        var result = input.SumOfEvenNUmbers();
        Assert.AreEqual(0,result);
    }
    //[TestCase(new int[] { 3, 1, 4, 6, 7 },10)]
    //[TestCase(new List<int> { 100,200,1 },300)]
    [TestCaseSource(nameof(GetSumOfEvenNumbersTestCases))]
    public void SumOfEvenNumbers_ShallReturnSum_IfevenNumbersArePresent(IEnumerable<int> input, int expected)
    {
        var result = input.SumOfEvenNUmbers();
        var inputAsString = string.Join(", ",input);
        Assert.AreEqual(expected, result,$"For input {inputAsString} " + $"the result shall be {expected} but it was {result}.");
    }
    public static IEnumerable<object> GetSumOfEvenNumbersTestCases()
    {
        return new[]
        {
            new object[] {new int[] { 3, 1, 4, 6, 7 },10},
            new object[] {new List<int> { 100,200,1},300 },
            new object[] {new List<int> { -3,-5,0},0 },
            new object[] {new List<int> { -4,-8},-12 },
        };
    }
    [TestCase(8)]
    [TestCase(-8)]
    [TestCase(0)]
    [TestCase(6)]
    public void SumOfEvenNumbers_ShallReturnValueOfTheOnlyItem_IfItIsEven(int number)
    {
        var input = new int[] { number };
        var result = input.SumOfEvenNUmbers();
     
        Assert.AreEqual(number, result);
    }
    [TestCase(1)]
    [TestCase(-7)]
    [TestCase(33)]
    public void SumOfEvenNumbers_ShallReturnZero_IfOnlyNumberIsInputIsOdd(int number)
    {
        var input = new int[] { number };
        var result = input.SumOfEvenNUmbers();

        Assert.AreEqual(0, result);
    }

    [TestCase(1, 2, 3)]
    [TestCase(1, -1, 0)]
    [TestCase(0, 0, 0)]
    [TestCase(100, -50, 50)]
    [TestCase(11, 12, 23)]
    public void Sum_ShallAddNumbersCorrectly(int a, int b, int expected)
    {
        var result = Calculator.Sum(a, b);
        Assert.AreEqual(expected, result,$"Adding {a} to {b} shall give {expected}, " + $"but the result  was {result}.");
    }
    [Test]
    public void SumOfEvenNumbers_ShallThrowException_ForNullInput()
    {
        IEnumerable<int>? input = null;
        Assert.Throws<ArgumentNullException>( () => input!.SumOfEvenNUmbers());
    }
}