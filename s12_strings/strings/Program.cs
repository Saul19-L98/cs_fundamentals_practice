string text = "abc";
text += "d";
Console.WriteLine(text);

var test = new TestStruct
{
    Text = "abc"
};

var other = test;

//var other = new TestStruct
//{
//    List = test.List
//};

Console.ReadKey();

public struct TestStruct
{
    public string Text { get; init; }
}