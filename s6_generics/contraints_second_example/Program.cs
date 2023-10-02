var people = new List<Person>
{
    new Person{Name = "John", YearOfBirth = 1980},
    new Person{Name = "Anna", YearOfBirth = 1815},
    new Person{Name = "Bill", YearOfBirth = 2150},
};

var employees = new List<Employee>
{
    new Employee{Name = "John", YearOfBirth = 1980},
    new Employee{Name = "Anna", YearOfBirth = 1815},
    new Employee{Name = "Bill", YearOfBirth = 2150},
};

var validPeople = GetOnlyValid(people);
var validEmployees = GetOnlyValid(employees);

foreach (var employee in validEmployees)
{
    //((Employee)employee).GoToWork();
    employee.GoToWork();
}

Console.ReadKey();

IEnumerable<TPerson> GetOnlyValid<TPerson>(IEnumerable<TPerson> persons) where TPerson : Person
{
    var result = new List<TPerson>();
    foreach (var person in persons)
    {
        if (person.YearOfBirth > 1900 && person.YearOfBirth < DateTime.Now.Year)
        {
            result.Add(person);
        }
    }
    return result;
}

public class Person
{
    public string Name { get; set; }
    public int YearOfBirth { get; init; }
}
public class Employee : Person
{
    public void GoToWork() => Console.WriteLine("Going to work");
}




public class SortedList<T> where T : IComparable<T>
{
    public IEnumerable<T> Items { get; }

    public SortedList(IEnumerable<T> items)
    {
        var asList = items.ToList();
        asList.Sort();
        Items = asList;
    }
}

public class FullName : IComparable<FullName>
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public override string ToString() => $"{FirstName} {LastName}";

    public int CompareTo(FullName fullName)
    {
        int lastNameComparison = string.Compare(LastName, fullName.LastName);
        int firstNameComparison = string.Compare(FirstName, fullName.FirstName);

        if (lastNameComparison < 0 && firstNameComparison < 0)
        {
            return 1;
        }
        else if (lastNameComparison > 0 && firstNameComparison > 0)
        {
            return -1;
        }
        return 0;
    }
}