using Cookbook.App.UI;

namespace Cookbook.App.Repository;

public class RecipeRepository : IRecipeRepository
{
    private IStringRepoManager _stringRepoManager;
    private ICookbookInteraction _cookbookUI;

    public RecipeRepository(IStringRepoManager stringRepoManager)
    {
        _stringRepoManager = stringRepoManager;
        _cookbookUI = new CookbookInteraction();
    }
    public void SaveRecipes(Recipe recipe)
    {
        _cookbookUI.GetSelectedIngredients(recipe);

        List<int> ingredientIds = recipe._ingredients
        .Select(i => i.Id)
        .Distinct()
        .ToList();
        string recipeLine = string.Join(",", ingredientIds);

        _stringRepoManager.SaveRecipes(recipe, recipeLine);
    }

    public List<string> PrintRecipes()
    {
        return _stringRepoManager.ReadRecipe();
    }
}

