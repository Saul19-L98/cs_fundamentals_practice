
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

var countOfDogs = pets.Count(pet => pet.Type == PetType.Dog);
Console.WriteLine(countOfDogs);

var countOfPetsNamedBruce = pets.LongCount(pet => pet.Name == "Bruce");
Console.WriteLine($"Pets named Bruce: {countOfPetsNamedBruce}");

var countOfAllSamallDogs = pets.Count(pet => pet.Type == PetType.Dog && pet.Height < 10);
Console.WriteLine($"Small dogs count: {countOfAllSamallDogs}");

var countAll = pets.Count();
Console.WriteLine("Count of all pets in the collection " + countAll);

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


