using firstAssignment;
using NUnit.Framework;

namespace firstAssignmentTests;

public class FibonacciNumbersTests
{
    [TestCase(-1)]
    [TestCase(-24)]
    [TestCase(47)]
    [TestCase(50)]
    [TestCase(140)]
    public void Generate_ShallReturnException_IfNumberIsOutOfRange(int number)
    {
        Assert.Throws<ArgumentException>( () => Fibonacci.Generate(number));
    }
    [TestCase(0)]
    public void Generate_ShallReturnEmptyList_IfNumberIsZero(int number)
    {
        Assert.IsEmpty(Fibonacci.Generate(number));
    }
    [TestCase(1)]
    public void Generate_ShallReturnListWithOnlyOneItem_IfNumberIsOne(int number)
    {
        var expected = new List<int>(1) { 0 };
        Assert.AreEqual(expected, Fibonacci.Generate(number));
    }
    [TestCaseSource(nameof(GetAValidSequence))]
    public void Generate_ShallReturnSequence_IfNumberIsValid(int number, IEnumerable<int> expected)
    {
        var result = Fibonacci.Generate(number);
        var inputAsString = string.Join(", ", result);
        Assert.AreEqual(expected, result, $"For input {inputAsString} " + $"the result shall be {expected} but it was {result}.");
    }
    private static IEnumerable<object> GetAValidSequence()
    {
        return new[]
        {
            new object[] {5,new List<int> { 0,1,1,2,3 } },
            new object[] {6,new List<int> { 0, 1, 1, 2, 3, 5 } },
            new object[] {10,new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 }}
        };
    }
    [Test]
    public void Generate_ShallProduceSequenceWithLastNumber_1134903170_ForNEqualTo46()
    {
        var result = Fibonacci.Generate(46);
        int expected = 1134903170;
        Assert.AreEqual(expected,result.Last());
    }
}