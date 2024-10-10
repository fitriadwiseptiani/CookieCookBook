using Cookbook.App.Repository;
using Cookbook.App;
using Cookbook.Enums;
using Cookbook.App.UI;

namespace CookbookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInteraction ui = new ConsoleUserInteraction();
            ICookbookInteraction cookbookUI = new CookbookInteraction();

            IStringRepoManager _stringRepoManager;
            ui.WriteMessage("Choose format to save your recipes: 1. JSON 2. TXT");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                _stringRepoManager = new JsonBasedStringRepo();
            }
            else
            {
                _stringRepoManager = new TxtBasedStringRepo();
            }
            IRecipeRepository repository = new RecipeRepository(_stringRepoManager);

            repository.PrintRecipes();

            ICookbook cookbook = new CookieCookbook(repository, ui, cookbookUI);            
            try
            {
                var result = cookbook.MakeNewRecipe();

            }
            catch (Exception e)
            {
                //Log and close the application gracefully
                Console.WriteLine($"{e}");
            }
        }
    }
}

