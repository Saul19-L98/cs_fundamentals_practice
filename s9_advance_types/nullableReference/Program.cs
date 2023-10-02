string? nonNullableString = null;
Console.WriteLine(nonNullableString);

static string FormatHouseData(IEnumerable<House> houses)
{
    return string.Join("\n",houses.Select(house => $"Owner is {house.OwnerName}, address is {house.Address.Number} {house.Address.Street}"));
}

Console.ReadKey();

class House
{
    public string OwnerName { get; }
    public Address Address { get; } 
    public House(string ownerName,Address address)
    {
        OwnerName = ownerName ?? throw new ArgumentNullException(nameof(ownerName));
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }
}

class Address 
{
    public string Street { get; }
    public string Number { get; }
    public Address(string street, string number)
    {
        Street = street;
        Number = number;
    }
}
