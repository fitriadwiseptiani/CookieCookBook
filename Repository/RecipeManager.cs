// using System.Net;
// using System.Text.Json;
// using CookieCookbook.Controller;
// using CookieCookbook.Interface;

// namespace CookieCookbook.Classes;

// public class RecipeManager
// {
//     private readonly IRecipePrint _recipePrint;

//     public RecipeManager(IRecipePrint recipePrint)
//     {
//         _recipePrint = recipePrint;
//     }
//     public void SaveRecipe(List<IIngredient> ingredients)
//     {
//         if (ingredients.Count == 0)
//         {
//             Console.WriteLine("No ingredients selected. Recipe will not be saved.");
//             return;
//         }
//         Console.WriteLine("Selected ingredients IDs: " + string.Join(", ", ingredients.Select(i => i.Id)));
        
//         List<int> ingredientIds = ingredients.Select(i => i.Id).ToList();
//         string recipeLine = string.Join(",", ingredientIds);

//         string filePath = "./Json/recipes.json";
//         List<string> recipes;

//         if (File.Exists(filePath))
//         {
//             string json = File.ReadAllText(filePath);
//             recipes = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
//         }
//         else
//         {
//             recipes = new List<string>();
//         }

//         recipes.Add(recipeLine);

//         string serializedJson = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
//         File.WriteAllText(filePath, serializedJson);

//         Console.WriteLine("Recipe saved: " + recipeLine);
//     }
//     public string PrintRecipe(CookieController cookie, List<int> ingredientIds)
//     {
//         return _recipePrint.PrintRecipe(cookie, ingredientIds);
//     }
//     public void PrintAllRecipe(CookieController cookie)
//     {

//         string filePath = "./Json/recipes.json";
//         if (!File.Exists(filePath))
//         {
//             Console.WriteLine("No recipes found.");
//             return;
//         }

//         string json = File.ReadAllText(filePath);
//         List<string> recipes = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();

//         Console.WriteLine("\nAll Recipes:");
//         for (int i = 0; i < recipes.Count; i++)
//         {
//             string recipe = recipes[i];
//             List<int> ingredientIds = recipe.Split(',').Select(int.Parse).ToList();
//             Console.WriteLine($"***** Recipe {i + 1} *****");
//             Console.WriteLine(PrintRecipe(cookie, ingredientIds));
//             Console.WriteLine("");
//         }
//     }
// }

