using System.Text.Json;
using Cookbook.App;

namespace Cookbook.App.Repository;

public class JsonBasedStringRepo : IStringRepoManager
{
    private readonly string filePath = "./File/recipes.json";
    public JsonBasedStringRepo()
    {
    }
    public void SaveRecipes(IEnumerable<Recipe> recipe, string recipeLine)
    {
        List<string> recipes = LoadFile(filePath);
        recipes.Add(recipeLine);

        string serializedJson = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, serializedJson);
    }

    public IEnumerable<Recipe> ReadRecipe()
    {
        if (!File.Exists(filePath))
        {
            throw new Exception("Sorry no recipes found");

        }
        string json = File.ReadAllText(filePath);
        List<string> recipe = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
        if (recipe.Count == null)
        {
            throw new Exception();
        }
        recipe.Select((recipeData, index) => new { recipeData, index }).ToList().ForEach(p =>
        {
            List<int> ingredientIds = p.recipeData.Split(',').Select(int.Parse).ToList();
        });
        return List<int> ingredientIds;
    }
    

    static List<string> LoadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<string>();
        }
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
    }

}
