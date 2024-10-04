using CookieCookbook.Container;

namespace CookieCookbook.Repository;

public class RecipeFactory : Recipe
{
    private IngredientContainer _ingredientContainer = new();
    public RecipeFactory(List<IIngredientBase> ingredientBases) : base(ingredientBases)
    {
    }

    public override void MakeNewRecipe(string inputPlayer, List<IIngredientBase> ingredients)
    {
        if (Int32.TryParse(inputPlayer, out int id))
        {
            var ingredient = _ingredientContainer.GetIngredientsList().Find(a => a.Id == id);
            if (!(ingredient == null))
            {
                ingredients.Add(ingredient);
                Console.WriteLine($"{ingredient.IngredientName} was added to recipe");
            }
            else
            {
                Console.WriteLine("Please input the valid number. no ingredient was matched with id that you input");
            }

        }
        else
        {
            Console.WriteLine("Invalid input. Please input a number.");
        }
    }

}
