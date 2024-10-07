using CookieCookbook.RecipeData;

namespace CookieCookbook.Repository;

public interface IStringRepoManager
{
    void SaveRecipe(IRecipeBase recipe, string recipeLine);
    void PrintAllRecipe();
}
