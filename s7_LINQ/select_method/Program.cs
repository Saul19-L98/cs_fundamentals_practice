var numbers = new[] { 10, 1, 4, 17, 122 };
var doubleNumbers = numbers.Select(number => number * 2);

foreach (var dubleNumber in doubleNumbers)
{
    Console.WriteLine(dubleNumber);
}

var words = new[] { "little", "brown", "fox" };
var toUppercase = words.Select(word => word.ToUpper());

foreach (var word in toUppercase)
{
    Console.WriteLine(word);
}

var numberedWords = words.Select((word, index) => $"{index + 1}. {word}");

foreach (var numberedWord in numberedWords)
{
    Console.WriteLine(numberedWord);
}

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

var heights = pets.Where(pet => pet.Height > 4).Select(pet => pet.Height).Distinct();
Console.WriteLine(nameof(heights));
foreach (var height in heights)
{
    Console.WriteLine($"{height}");
}

var petsInitials = pets.OrderBy(pet => pet.Name).Select(pet => $"{pet.Name.First()}.");
Console.WriteLine(nameof(petsInitials));
foreach (var petsInitial in petsInitials)
{
    Console.WriteLine($"{petsInitial}");
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
