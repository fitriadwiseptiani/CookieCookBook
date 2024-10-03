using System.Diagnostics;
using System.Text.Json;
using CookieCookbook.Container;
using CookieCookbook.Enums;

namespace CookieCookbook.Repository
{
    public class RecipeRepo
    {
        private IStringRepoManager _stringRepoManager;
        public Recipe RecipeData;
        public string RepoManager{get; set;}

        public RecipeRepo(string repoManager, IStringRepoManager stringRepoManager)
        {
            RepoManager = repoManager;
            _stringRepoManager = stringRepoManager;
        }
        public void SaveRecipe()
        {
            _stringRepoManager.SaveRecipe();
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
        public void PrintAllRecipe(){
            _stringRepoManager.PrintRecipe();
        }

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
        public void SaveRecipeToJson()
        {
            List<int> ingredientIds = RecipeData.Ingredients.Select(i => i.Id).ToList();
            string recipeLine = string.Join(",", ingredientIds);
            string filePath = "./Json/recipes.json";
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

        public void PrintAllRecipeFromJson(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipe can be displayed.");
                return;
            }

            string filePath = "./Json/recipes.json";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            string json = File.ReadAllText(filePath);
            List<string> recipe = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();

            Console.WriteLine("\nAll Recipes:");
            for (int i = 0; i < recipe.Count; i++)
            {
                string allRecipe = recipe[i];
                List<int> ingredientIds = allRecipe.Split(',').Select(int.Parse).ToList();
                Console.WriteLine($"***** Recipe {i + 1} *****");
                Console.WriteLine(PrintRecipe(RecipeData, ingredientIds));
                Console.WriteLine("");
            }

        }
        public void SaveRecipeToTxt(){
            List<int> ingredientIds = RecipeData.Ingredients.Select(i => i.Id).ToList();
            string recipeLine = string.Join(",", ingredientIds);
            string filePath = "./Json/recipes.txt";
            List<string> recipes;

            if (File.Exists(filePath))
            {
                string txt = File.ReadAllText(filePath);
                recipes = JsonSerializer.Deserialize<List<string>>(txt) ?? new List<string>();
            }
            else
            {
                recipes = new List<string>();
            }

            recipes.Add(recipeLine);

            string serializedJson = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, serializedJson);
        }
        public void PrintAllRecipeFromTxt(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipe can be displayed.");
                return;
            }

            string filePath = "./Json/recipes.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            string txt = File.ReadAllText(filePath);
            List<string> recipe = JsonSerializer.Deserialize<List<string>>(txt) ?? new List<string>();

            Console.WriteLine("\nAll Recipes:");
            for (int i = 0; i < recipe.Count; i++)
            {
                string allRecipe = recipe[i];
                List<int> ingredientIds = allRecipe.Split(',').Select(int.Parse).ToList();
                Console.WriteLine($"***** Recipe {i + 1} *****");
                Console.WriteLine(PrintRecipe(RecipeData, ingredientIds));
                Console.WriteLine("");
            }

        }
        public string PrintRecipe(Recipe recipes, List<int> ingredientIds)
        {
            List<string> ingredientDetails = new List<string>();

            foreach (int id in ingredientIds)
            {
                Ingredient ingredient = recipes.Ingredients.Find(a => a.Id == id);
                if (ingredient != null)
                {
                    ingredientDetails.Add($"{ingredient.IngredientName}. {string.Join(". ", ingredient.Instructions)}");
                }
            }

            return string.Join("\n", ingredientDetails);
        }
    }
}


