namespace CookieCookbook.Repository;

public interface IStringRepoManager
{
    void SaveRecipe(string recipeLine);
    void PrintAllRecipe(string filePath, IRecipeBase recipes);
}
