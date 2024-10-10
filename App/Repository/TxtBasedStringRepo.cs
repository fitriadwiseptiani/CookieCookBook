using Cookbook.App;

namespace Cookbook.App.Repository;

public class TxtBasedStringRepo : IStringRepoManager
{
    
    private readonly string filePath = "./File/recipes.txt";
    public TxtBasedStringRepo()
    {
    }

    public void SaveRecipes(string recipeLine)
    {
        List<string> recipes = LoadFile(filePath);

        recipes.Add(recipeLine);

        File.WriteAllLines(filePath, recipes);
    }

    public void ReadRecipe()
    {
        // file exist
        List<string> recipes = LoadFile(filePath);
         
        //  recipes.Select((recipeData, index) => new { recipeData, index })
        //    .ToList()
        //    .ForEach(r =>
        //    {
        //        List<int> ingredientIds = r.recipeData.Split(',').Select(int.Parse).ToList();
        //        Console.WriteLine($"***** Recipe {r.index + 1} *****");
        //        Console.WriteLine(PrintRecipe(ingredientIds));
        //        Console.WriteLine("");
        //    });

    }
    static List<string> LoadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<string>();
        }
        return File.ReadAllLines(filePath).ToList();
    }
}
