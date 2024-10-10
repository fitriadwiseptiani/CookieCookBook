using Cookbook.App;

namespace Cookbook.App.Repository;

public interface IStringRepoManager
{
    void SaveRecipes(IEnumerable<Recipe> recipe);
    IEnumerable<Recipe> ReadRecipe();
}
