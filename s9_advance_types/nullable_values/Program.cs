//Sintetic sugar!
int? numberOrNull = null;

Nullable<bool> boolOrNull = true;

if (numberOrNull.HasValue)
{
    Console.WriteLine("not null");
}
if(boolOrNull is not null)
{
    var someBool = boolOrNull.Value;
    Console.WriteLine(someBool);
}


var heights = new List<Nullable<int>>
{
    160,null,185,null,170
};
var averageHeight = heights.Average();
Console.WriteLine(averageHeight);

Console.ReadKey();