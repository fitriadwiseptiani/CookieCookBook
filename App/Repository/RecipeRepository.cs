using Cookbook.App;

namespace Cookbook.App.Repository;

public class RecipeRepository : IRecipeRepository
{
    private IStringRepoManager _stringRepoManager;
    private readonly IUserInteraction _ui;

    public RecipeRepository(IStringRepoManager stringRepoManager){
        _stringRepoManager = stringRepoManager;
    }
    public void SaveRecipes(Recipe recipe)
    {
        if(recipe._ingredients.Count == 0){
            return;
        }

        List<int> ingredientIds = recipe._ingredients.Select(i => i.Id).ToList();
        string recipeLine = string.Join(",", ingredientIds);

        _stringRepoManager.SaveRecipe(recipe);
    }
    public IEnumerable<Recipe> PrintRecipes()
    {
        return _stringRepoManager.ReadRecipe();
    }

    public string PrintSingleRecipe(List<int> ingredientIds)
    {
        List<string> ingredientDetails = new List<string>();

        foreach (int id in ingredientIds)
        {
            IIngredient? ingredient = _ingredientContainer.GetIngredientsList().Find(a => a.Id == id);
            if (ingredient != null)
            {
                ingredientDetails.Add($"{ingredient.IngredientName}. {string.Join(". ", ingredient.Instructions)}");
            }
            else
            {
                Console.WriteLine($"Ingredient with ID {id} not found in recipe.");
            }
        }
        return string.Join("\n", ingredientDetails);
    }

    
}
