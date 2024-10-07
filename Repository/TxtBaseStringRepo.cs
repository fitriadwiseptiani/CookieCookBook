
namespace CookieCookbook.Repository;

public class TxtBaseStringRepo : IStringRepoManager
{
    public void SaveRecipe(IRecipeBase recipe)
    {
        string filePath = "./File/recipes.txt";
        List<string> recipes = LoadFile(filePath);

        recipes.Add(recipe.ToString());
        File.WriteAllLines(filePath, recipes);
    }
    

    public void PrintAllRecipe(List<IRecipeBase> recipes)
    {
        foreach (var recipe in recipes)
        {
            Console.WriteLine(recipe.ToString()); 
        }
    }
    public List<string> LoadFile(string filePath)
    {
        if (!File.Exists(filePath))
            return new List<string>(); 

        return File.ReadAllLines(filePath).ToList();
    }

}
