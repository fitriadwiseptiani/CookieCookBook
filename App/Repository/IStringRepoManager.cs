using Cookbook.App;

namespace Cookbook.App.Repository;

public interface IStringRepoManager
{
    void SaveRecipes(string recipeLine);
    void ReadRecipe();
}
