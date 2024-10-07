using CookieCookbook.Container;
using CookieCookbook.Container.IngredientContainer;

namespace CookieCookbook.RecipeData;

public class RecipeFactory : Recipe
{
    private IngredientContainer _ingredientContainer;

    public RecipeFactory(int id, List<IIngredientBase> ingredientBases, IngredientContainer ingredientContainer) : base(id, ingredientBases, ingredientContainer)
    {
        _ingredientContainer = ingredientContainer;
    }

    public void MakeNewRecipe(string inputPlayer, List<IIngredientBase> ingredientBases)
    {
        if (Int32.TryParse(inputPlayer, out int id))
        {
            IIngredientBase ingredients = _ingredientContainer.GetIngredientsList().Find(a => a.Id == id);
            if (ingredientBases != null)
            {
                ingredientBases.Add(ingredients);
                Console.WriteLine($"{ingredients.IngredientName} was added to recipe \n");
            }
            else
            {
                Console.WriteLine("Please input the valid number. no ingredient was matched with id that you input");
                return;
            }
        }
    }
}
