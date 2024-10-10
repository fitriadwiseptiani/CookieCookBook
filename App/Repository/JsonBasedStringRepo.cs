using System.Text.Json;
using Cookbook.App.UI;

namespace Cookbook.App.Repository;

public class JsonBasedStringRepo : IStringRepoManager
{
    private ICookbookInteraction _cookbookUI;
    private readonly string filePath = "./File/recipes.json";
    public JsonBasedStringRepo()
    {
        _cookbookUI = new CookbookInteraction();
    }
    public void SaveRecipes(Recipe recipe, string recipeLine)
    {
        List<string> recipes = _cookbookUI.LoadFileJson(filePath);
        recipes.Add(recipeLine);

        string serializedJson = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, serializedJson);
    }

    public List<string> ReadRecipe()
    {
        List<string> recipe = _cookbookUI.LoadFileJson(filePath);
        _cookbookUI.DisplayRecipe(recipe);
        return recipe;
    }
}
