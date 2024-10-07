using System.Text.Json;
using CookieCookbook.Container;

namespace CookieCookbook.Repository;

public class JsonBasedStringRepo : IStringRepoManager
{
    public void SaveRecipe(IRecipeBase recipe)
    {
        string filePath = "./File/recipes.json";
        List<IRecipeBase> recipes = LoadFile(filePath).Select(a => JsonSerializer.Deserialize<IRecipeBase>(a)).ToList();

        recipes.Add(recipe);

        string serializedJson = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, serializedJson);
    }
    public void PrintAllRecipe(List<IRecipeBase> recipeBases)
    {
        foreach (var recipe in recipeBases)
        {
            Console.WriteLine(recipe.ToString()); // Pastikan bahwa ToString() di Recipe terimplementasi dengan baik
        }
        // string json = File.ReadAllText(filePath);
        // List<string> recipe = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();

        // Console.WriteLine("\nAll Recipes:");

        // // for (int i = 0; i < recipe.Count; i++)
        // // {
        // //     string allRecipe = recipe[i];
        // //     List<int> ingredientIds = allRecipe.Split(',').Select(int.Parse).ToList();
        // //     Console.WriteLine($"***** Recipe {i + 1} *****");
        // //     Console.WriteLine(PrintRecipe(recipes, ingredientIds));
        // //     Console.WriteLine("");
        // // }

    }
    public string PrintRecipe(IRecipeBase recipes, List<int> ingredientIds)
    {
        List<string> ingredientDetails = new List<string>();

        foreach (int id in ingredientIds)
        {
            var ingredient = recipes.IngredientBases.Find(a => a.Id == id);
            if (ingredient != null)
            {
                ingredientDetails.Add($"{ingredient.IngredientName}. {string.Join(". ", ingredient.Instructions)}");
            }
        }

        return string.Join("\n", ingredientDetails);
    }
    public List<string> LoadFile(string filePath)
    {
        if (!File.Exists(filePath))
            return new List<string>();

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
    }

}
