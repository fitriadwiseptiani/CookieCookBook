namespace Cookbook.App;

public interface IRecipeRepository
{
    void SaveRecipes(IEnumerable<Recipe> recipes);
    IEnumerable<Recipe> PrintRecipes();
}
