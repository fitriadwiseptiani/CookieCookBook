namespace CookieCookbook.Repository;

public interface IStringRepoManager
{
    void SaveRecipe(IRecipeBase recipe);
    void PrintAllRecipe(List<IRecipeBase> recipes);
    List<string> LoadFile(string filePath);
}
