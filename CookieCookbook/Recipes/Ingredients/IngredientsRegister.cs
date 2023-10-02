namespace CookieCookbook.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
        var countOfIngredientsWithGivenId = All.Where(ingredient => ingredient.Id == id);

        if(countOfIngredientsWithGivenId.Count() > 1)
        {
            throw new InvalidOperationException($"More than one ingredients have ID equal to {id}.");
        }

        if(All.Select(ingredient => ingredient.Id).Distinct().Count() != All.Count())
        {
            throw new InvalidOperationException($"Some ingredients have duplicated IDs.");
        }

        return All.FirstOrDefault(ingredient => ingredient.Id == id);

        //foreach (var ingredient in All)
        //{
        //    if (ingredient.Id == id)
        //    {
        //        return ingredient;
        //    }
        //}

        //return null;
    }
}

