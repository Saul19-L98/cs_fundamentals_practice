var convert = new ObjectToTextConverter();
Console.WriteLine(convert.Convert(new House("123 Maple Road", 150.6, 2)));

Console.WriteLine("Press any key to close.");
Console.ReadKey();

class ObjectToTextConverter
{
    public string Convert(object obj)
    {
        Type type = obj.GetType();
        var properties = type.GetProperties().Where(p => p.Name != "EqualityContract");
        return String.Join(",", properties.Select(property => $"{property.Name} is {property.GetValue(obj)}"));
    }
}

public record Pet(string Name,PetType PetType,float Weight);
public record House(string Adderss,double Area,int Floors);
public enum PetType { Cat,Dog,Fish}