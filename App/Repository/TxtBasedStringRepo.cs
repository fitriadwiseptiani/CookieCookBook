using Cookbook.App.UI;

namespace Cookbook.App.Repository;

public class TxtBasedStringRepo : IStringRepoManager
{
    private readonly string filePath = "./File/recipes.txt";
    private readonly ICookbookInteraction _cookbookUI;
    public TxtBasedStringRepo()
    {
        _cookbookUI = new CookbookInteraction();
    }

    public void SaveRecipes(Recipe recipe, string recipeLine)
    {
        List<string> recipes = _cookbookUI.LoadFileTxt(filePath);

        recipes.Add(recipeLine);

        File.WriteAllLines(filePath, recipes);
    }

    public List<string> ReadRecipe()
    {
        List<string> recipe = _cookbookUI.LoadFileTxt(filePath);

        _cookbookUI.DisplayRecipe(recipe);

        return recipe;
    }

}
