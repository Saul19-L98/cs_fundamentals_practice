var employees = new List<Employee>
{
    new Employee("Jake Smith", "Space Navigation", 25000),
    new Employee("Anna Blake", "Space Navigation", 29000),
    new Employee("Barbara Oak", "Xenobiology", 21500),
    new Employee("Damien Parker", "Machanics", 21000),
    new Employee("Gustavo Sanchez", "Machanics", 20000),
};

var result = CalculateAverageSalaryPerDepartment(employees);

Console.ReadKey();

Dictionary<string,decimal> CalculateAverageSalaryPerDepartment(IEnumerable<Employee> employees)
{
    var employeesPerDepartments = new Dictionary<string, List<Employee>>();
    foreach (var employee in employees)
    {
        if (!employeesPerDepartments.ContainsKey(employee.Department))
        {
            employeesPerDepartments[employee.Department] = new List<Employee>();
        }
        employeesPerDepartments[employee.Department].Add(employee);
    }
    var result = new Dictionary<string, decimal>();
    foreach (var employeesPerDepartment in employeesPerDepartments)
    {
        decimal sumOfSalaries = 0;
        foreach (var employee in employeesPerDepartment.Value)
        {
            sumOfSalaries += employee.MonthlySalary;
        }
        var average = sumOfSalaries / employeesPerDepartment.Value.Count;
        result[employeesPerDepartment.Key] = average;
    }
    return result;
}

public class Employee
{
    public Employee(string name,string department, decimal monthlySalary)
    {
        Name = name;
        Department = department;
        MonthlySalary = monthlySalary;
    }
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal MonthlySalary { get; set; }
}



public static class Exercise
{
    public static Dictionary<PetType, double> FindMaxWeights(List<Pet> pets)
    {
        var petPerPetTypes = new Dictionary<PetType, List<Pet>>();
        foreach (var pet in pets)
        {
            if (!petPerPetTypes.ContainsKey(pet.PetType))
            {
                petPerPetTypes[pet.PetType] = new List<Pet>();
            }
            petPerPetTypes[pet.PetType].Add(pet);
        }
        var result = new Dictionary<PetType, double>();
        foreach (var petPerPetType in petPerPetTypes)
        {
            double maxWeight = 0;
            foreach (var pet in petPerPetType.Value)
            {
                if (maxWeight < pet.Weight)
                {
                    maxWeight = pet.Weight;
                }
            }
            result[petPerPetType.Key] = maxWeight;
        }
        return result;
    }
}

public class Pet
{
    public PetType PetType { get; }
    public double Weight { get; }

    public Pet(PetType petType, double weight)
    {
        PetType = petType;
        Weight = weight;
    }

    public override string ToString() => $"{PetType}, {Weight} kilos";
}

public enum PetType { Dog, Cat, Fish }