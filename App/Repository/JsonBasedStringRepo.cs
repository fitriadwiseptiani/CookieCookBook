using System.Text.Json;
using Cookbook.App;

namespace Cookbook.App.Repository;

public class JsonBasedStringRepo : IStringRepoManager
{
    private ConsoleUserInteraction _ui;
    private readonly string filePath = "./File/recipes.json";
    public JsonBasedStringRepo()
    {
    }
    public void SaveRecipes(string recipeLine)
    {
        List<string> recipes = LoadFile(filePath);
        recipes.Add(recipeLine);

        string serializedJson = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, serializedJson);
    }

    public void ReadRecipe()
    {
        _ui.FileExist(filePath);
        string json = File.ReadAllText(filePath);
        List<string> recipe = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
        //recipecount

        
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
