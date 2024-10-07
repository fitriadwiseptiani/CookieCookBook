
using CookieCookbook.Container;
using CookieCookbook.Container.IngredientContainer;
using CookieCookbook.RecipeData;

namespace CookieCookbook.Repository;

public class TxtBaseStringRepo : IStringRepoManager
{
    private readonly IngredientContainer _ingredientContainer;
    public readonly List<IRecipeBase> recipeBases;
    public TxtBaseStringRepo(IngredientContainer ingredientContainer)
    {
        _ingredientContainer = ingredientContainer;
    }
    public void SaveRecipe(IRecipeBase recipe, string recipeLine)
    {
        string filePath = "./File/recipes.txt";
        List<string> recipes = LoadFile(filePath);

        recipes.Add(recipeLine);

        File.WriteAllLines(filePath, recipes);
        Console.WriteLine("Recipe saved: " + recipeLine);
    }


    public void PrintAllRecipe()
    {
        string filePath = "./File/recipes.txt";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No recipes found.");
            return;
        }
        List<string> recipes = LoadFile(filePath);

        if (recipes.Count == null)
        {
            Console.WriteLine("There is no recipe can display. Please make new recipe");
            return;
        }

        recipes.Select((recipeData, index) => new { recipeData, index })
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
    public List<string> LoadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<string>();
        }
        return File.ReadAllLines(filePath).ToList();
    }
}
