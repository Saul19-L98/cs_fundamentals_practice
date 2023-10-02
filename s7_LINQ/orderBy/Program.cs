
using System;

var pets = new[]
{
    new Pet(1,"Hannibal", PetType.Fish, 1.1f),
    new Pet(2,"Anthony", PetType.Cat, 2f),
    new Pet(3,"Ed", PetType.Cat, 0.7f),
    new Pet(4,"Taiga", PetType.Dog, 35f),
    new Pet(5,"Rex", PetType.Dog, 40f),
    new Pet(6,"Lucky", PetType.Dog, 5f),
    new Pet(7,"Storm", PetType.Cat, 0.9f),
    new Pet(8,"Nyan", PetType.Cat, 2.2f),
    new Pet(9,"Bruce", PetType.Dog, 3.4f)
};

var petsOrderByName = pets.OrderBy(pet => pet.Name);

foreach (var petOrderedByName in petsOrderByName) 
{
    Console.WriteLine($"{petOrderedByName.Id},{petOrderedByName.Name},{petOrderedByName.Type},{petOrderedByName.Height}");
}

Console.WriteLine("");
Console.WriteLine("Wihout ordering: ");
foreach (var pet in pets)
{
    Console.WriteLine($"{pet.Id},{pet.Name},{pet.Type},{pet.Height}");
}

var petsOrderByIdDesc = pets.OrderByDescending(pet => pet.Id);

Console.WriteLine("");
Console.WriteLine("Desc ordering: ");
foreach (var pet in petsOrderByIdDesc)
{
    Console.WriteLine($"{pet.Id},{pet.Name},{pet.Type},{pet.Height}");
}


Console.ReadKey();

public enum PetType { Dog, Cat, Fish }

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public PetType Type { get; set; }
    public float Height { get; set; }
    public Pet(int id, string name, PetType type, float height)
    {
        Id = id;
        Name = name;
        Type = type;
        Height = height;
    }
}

public class Exercise
{
    public static IEnumerable<DateTime> GetFridaysOfYear(int year, IEnumerable<DateTime> dates) => dates.Where(date => date.DayOfWeek == DayOfWeek.Friday && year == 2023).Distinct();
}