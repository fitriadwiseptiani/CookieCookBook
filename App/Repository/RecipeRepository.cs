using Cookbook.App;
using Cookbook.Model;

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

        _stringRepoManager.SaveRecipes(recipeLine);
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
            Ingredient? ingredient = _ui.GetIngredientsList().Find(a => a.Id == id);
            if (ingredient != null)
            {
                ingredientDetails.Add($"{ingredient.Name}. {string.Join(". ", ingredient.InstructionPreparation)}");
            }
            else
            {
                Console.WriteLine($"Ingredient with ID {id} not found in recipe.");
            }
        }
        return string.Join("\n", ingredientDetails);
    }

    
}
