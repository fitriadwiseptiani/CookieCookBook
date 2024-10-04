using System.Text.Json;
using CookieCookbook.Container;

namespace CookieCookbook.Repository;

public class JsonBasedStringRepo : IStringRepoManager
{
    public void SaveRecipe(string recipeLine)
    {
        string filePath = "./File/recipes.json";

        List<string> recipes;

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            recipes = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
        }
        else
        {
            recipes = new List<string>();
        }

        recipes.Add(recipeLine);

        string serializedJson = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, serializedJson);
    }
    public void PrintAllRecipe(string filePath, IRecipeBase recipes)
    {
        string json = File.ReadAllText(filePath);
        List<string> recipe = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();

        Console.WriteLine("\nAll Recipes:");

        // for (int i = 0; i < recipe.Count; i++)
        // {
        //     string allRecipe = recipe[i];
        //     List<int> ingredientIds = allRecipe.Split(',').Select(int.Parse).ToList();
        //     Console.WriteLine($"***** Recipe {i + 1} *****");
        //     Console.WriteLine(PrintRecipe(recipes, ingredientIds));
        //     Console.WriteLine("");
        // }

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

}
