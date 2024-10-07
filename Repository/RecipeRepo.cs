using System.Diagnostics;
using System.Text.Json;
using CookieCookbook.Container;
using CookieCookbook.Enums;

namespace CookieCookbook.Repository
{
    public class RecipeRepo
    {
        private IStringRepoManager _stringRepoManager;
        private IRecipeBase _recipe;
        private readonly string _filePath;
        private List<IRecipeBase> _recipes;

        public RecipeRepo(IStringRepoManager stringRepoManager, string filePath)
        {
            _stringRepoManager = stringRepoManager;
            _filePath = filePath;
            _recipes = LoadFile();
        }
        public void SaveRecipe(IRecipeBase recipe)
        {
            if (recipe.IngredientBases.Count == 0)
        {
            Console.WriteLine("No ingredients selected. Recipe will not be saved.");
            return;
        }
        Console.WriteLine("Selected ingredients IDs: " + string.Join(", ", recipe.IngredientBases.Select(i => i.Id)));
            List<int> ingredientIds = recipe.IngredientBases.Select(i => i.Id).ToList();
            string recipeLine = string.Join(",", ingredientIds);
            _recipes.Add(recipe);
            _stringRepoManager.SaveRecipe(recipe);
            // if(RepoManager == "json"){
            //     SaveRecipeToJson();
            // }
            // else if(RepoManager == "txt"){
            //     SaveRecipeToTxt();
            // }
            // else{
            //     throw new Exception("There is no spesific format file that can executed");
            // }

        }
        private List<IRecipeBase> LoadFile()
        {
            try
            {
                var recipesJson = _stringRepoManager.LoadFile(_filePath);
                return recipesJson.Select(json => JsonSerializer.Deserialize<IRecipeBase>(json)).Where(r => r != null).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading recipes: {ex.Message}");
                return new List<IRecipeBase>();
            }
        }
        public void PrintAllRecipe() {
            Console.WriteLine("All Recipes:");
            foreach (var recipe in _recipes)
            {
                Console.WriteLine($"Recipe ID: {recipe.Id}");
                foreach (var ingredient in recipe.IngredientBases)
                {
                    Console.WriteLine($" - {ingredient.IngredientName}");
                }
            }
        }
        // public void PrintAllRecipe(List<Recipe> recipes){
        //     if (recipes.Count == 0)
        //     {
        //         Console.WriteLine("No recipe can be displayed.");
        //         return;
        //     }
        //     string filePath = "./Json/recipes.json";
        //     if (!File.Exists(filePath))
        //     {
        //         Console.WriteLine("No recipes found.");
        //         return;
        //     }



        //     _stringRepoManager.PrintRecipe();
        // }

        // public void PrintAllRecipe(List<Recipe> recipes)
        // {
        //     if(RepoManager == "json"){
        //         PrintAllRecipeFromJson(recipes);
        //     }
        //     else if(RepoManager == "txt"){
        //         PrintAllRecipeFromTxt(recipes);
        //     }
        //     else{
        //         throw new Exception("There is no spesific format file that can executed");
        //     }

        // }

        // public void PrintAllRecipeFromJson(List<Recipe> recipes)
        // {
        //     if (recipes.Count == 0)
        //     {
        //         Console.WriteLine("No recipe can be displayed.");
        //         return;
        //     }

        //     string filePath = "./Json/recipes.json";
        //     if (!File.Exists(filePath))
        //     {
        //         Console.WriteLine("No recipes found.");
        //         return;
        //     }

        //     string json = File.ReadAllText(filePath);
        //     List<string> recipe = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();

        //     Console.WriteLine("\nAll Recipes:");
        //     for (int i = 0; i < recipe.Count; i++)
        //     {
        //         string allRecipe = recipe[i];
        //         List<int> ingredientIds = allRecipe.Split(',').Select(int.Parse).ToList();
        //         Console.WriteLine($"***** Recipe {i + 1} *****");
        //         Console.WriteLine(PrintRecipe(RecipeData, ingredientIds));
        //         Console.WriteLine("");
        //     }

        // }
        // public void SaveRecipeToTxt(){
        //     List<int> ingredientIds = RecipeData.Ingredients.Select(i => i.Id).ToList();
        //     string recipeLine = string.Join(",", ingredientIds);
        //     string filePath = "./Json/recipes.txt";
        //     List<string> recipes;

        //     if (File.Exists(filePath))
        //     {
        //         string txt = File.ReadAllText(filePath);
        //         recipes = JsonSerializer.Deserialize<List<string>>(txt) ?? new List<string>();
        //     }
        //     else
        //     {
        //         recipes = new List<string>();
        //     }

        //     recipes.Add(recipeLine);

        //     string serializedJson = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
        //     File.WriteAllText(filePath, serializedJson);
        // }
        // public void PrintAllRecipeFromTxt(List<Recipe> recipes)
        // {
        //     if (recipes.Count == 0)
        //     {
        //         Console.WriteLine("No recipe can be displayed.");
        //         return;
        //     }

        //     string filePath = "./Json/recipes.txt";
        //     if (!File.Exists(filePath))
        //     {
        //         Console.WriteLine("No recipes found.");
        //         return;
        //     }

        //     string txt = File.ReadAllText(filePath);
        //     List<string> recipe = JsonSerializer.Deserialize<List<string>>(txt) ?? new List<string>();

        //     Console.WriteLine("\nAll Recipes:");
        //     for (int i = 0; i < recipe.Count; i++)
        //     {
        //         string allRecipe = recipe[i];
        //         List<int> ingredientIds = allRecipe.Split(',').Select(int.Parse).ToList();
        //         Console.WriteLine($"***** Recipe {i + 1} *****");
        //         Console.WriteLine(PrintRecipe(RecipeData, ingredientIds));
        //         Console.WriteLine("");
        //     }

        // }
        // public string PrintRecipe(Recipe recipes, List<int> ingredientIds)
        // {
        //     List<string> ingredientDetails = new List<string>();

        //     foreach (int id in ingredientIds)
        //     {
        //         Ingredient ingredient = recipes.Ingredients.Find(a => a.Id == id);
        //         if (ingredient != null)
        //         {
        //             ingredientDetails.Add($"{ingredient.IngredientName}. {string.Join(". ", ingredient.Instructions)}");
        //         }
        //     }

        //     return string.Join("\n", ingredientDetails);
        // }
    }
}


