using Cookbook.App.Repository;
using Cookbook.App;
using Cookbook.Enums;

namespace CookbookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IStringRepoManager _stringRepoManager;
            Console.WriteLine("Choose format to save recipes: 1. JSON 2. TXT");
            int choice = int.Parse(Console.ReadLine());

            string filePath;

            if (choice == 1)
            {
                _stringRepoManager = new JsonBasedStringRepo();
            }
            else
            {
                _stringRepoManager = new TxtBasedStringRepo();
            }
            IEnumerable<Recipe> recipes;
            IRecipeRepository repository = new RecipeRepository(_stringRepoManager);
            IUserInteraction ui = new ConsoleUserInteraction();

            ICookbook cookbook = new CookieCookbook(repository, ui);
            try
            {
                var result = cookbook.MakeNewRecipe();
                if (result == CookbookErrorCode.NoError)
                {
                    Console.WriteLine("Recipe created successfully.");
                }
                else
                {
                    Console.WriteLine($"An error occurred: {result}");
                }
            }
            catch (Exception e)
            {
                //Log and close the application gracefully
                Console.WriteLine($"{e}");
            }
        }
    }
}

