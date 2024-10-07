using System.Text.Json;
using CookieCookbook.Container;
using CookieCookbook.Container.IngredientContainer;
using CookieCookbook.RecipeData;

namespace CookieCookbook.Repository;

public class JsonBasedStringRepo : IStringRepoManager
{
    private readonly IngredientContainer _ingredientContainer;
    private readonly List<IRecipeBase> _recipeBase;
    public JsonBasedStringRepo(IngredientContainer ingredientContainer)
    {
        _ingredientContainer = ingredientContainer;
    }
    public void SaveRecipe(IRecipeBase recipe, string recipeLine)
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
        Console.WriteLine("Recipe saved: " + recipeLine);
    }
    public void PrintAllRecipe()
    {
        string filePath = "./File/recipes.json";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No recipes found.");
            return;
        }
        string json = File.ReadAllText(filePath);
        List<string> recipe = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();

        if (recipe.Count == null)
        {
            Console.WriteLine("There is no recipe can display. Please make new recipe");
            return;
        }

        recipe.Select((recipeData, index) => new { recipeData, index })
           .ToList()
           .ForEach(r =>
           {
               List<int> ingredientIds = r.recipeData.Split(',').Select(int.Parse).ToList();
               Console.WriteLine($"***** Recipe {r.index + 1} *****");
               Console.WriteLine(PrintRecipe(ingredientIds));
               Console.WriteLine("");
           });
    }
    public string PrintRecipe(List<int> ingredientIds)
    {
        List<string> ingredientDetails = new List<string>();

        foreach (int id in ingredientIds)
        {
            IIngredientBase? ingredient = _ingredientContainer.GetIngredientsList().Find(a => a.Id == id);
            if (ingredient != null)
            {
                ingredientDetails.Add($"{ingredient.IngredientName}. {string.Join(". ", ingredient.Instructions)}");
            }
            else
            {
                Console.WriteLine($"Ingredient with ID {id} not found in recipe.");
            }
        }
        return string.Join("\n", ingredientDetails);
    }

}
