int number = 5;
var person = new Person { Name = "Ted" , Age =19};
object boxedNumber = number;
int unboxedNumber = (int)boxedNumber;

var variousObjects = new List<object>
{
    1,
    1.5m,
    new DateTime(2024,6,1),
    "hello",
    new Person{Name = "Anna", Age = 61}
};

foreach (object someObject in variousObjects)
{
    Console.WriteLine(someObject.GetType().Name);
}

Console.ReadKey();

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}