using System.ComponentModel.DataAnnotations;

var validPerson = new Person("John", 1981);
var invalidDog = new Dog("R");
var validator = new Validator();

Console.WriteLine(validator.Validate(validPerson) ? "Person is valid" : "Person is invalid");
Console.WriteLine(validator.Validate(invalidDog) ? "Dog is valid" : "Dog is invalid");
Console.ReadKey();

public class Dog
{
    [StringLengthValidate(2,10)]
    public string Name { get; }// length must be between 2 and 10
    public Dog(string name) => Name = name;
}

public class Person
{
    [StringLengthValidate(2, 25)]
    public string Name { get; set; }// length must be between 2 and 25
    public int YearOfBirth { get; set; }
    public Person(string name, int yearOfBirth) 
    {
        Name = name;
        YearOfBirth = yearOfBirth;
    }
    public Person(string name) => Name = name;
}

[AttributeUsage(AttributeTargets.Property)]
class StringLengthValidateAttribute : Attribute
{
    public int Min { get;}
    public int Max { get; }
    public StringLengthValidateAttribute(int min,int max)
    {
        Min = min;
        Max = max;
    }
}

class Validator
{
    public bool Validate(object obj)
    {
        var type = obj.GetType();
        var propertiesToValidate = type.GetProperties().Where(property => Attribute.IsDefined(property, typeof(StringLengthValidateAttribute)));
        foreach (var property in propertiesToValidate)
        {
            object? propertyValue = property.GetValue(obj);
            if (propertyValue is not string)
            {
                throw new InvalidOperationException($"Attribute {nameof(StringLengthValidateAttribute)}" + $" can only be applied to strings");
            }
            var value = (string)propertyValue;
            var attribute = (StringLengthValidateAttribute)property.GetCustomAttributes(typeof(StringLengthValidateAttribute), true).First();
            if (value.Length < attribute.Min || value.Length > attribute.Max) 
            {
                Console.WriteLine($"Property {property.Name} is invalid." + $" Value is {value}");
                return false;
            }
        }
        return true;
    }
}