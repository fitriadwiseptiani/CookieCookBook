using Cookbook.App.Repository;
using Cookbook.App;

        private IStringRepoManager _stringRepoManager;
    IEnumerable<Recipe> recipes = new Recipe();
    IRecipeRepository repository = new RecipeRepository();
    IUserInteraction ui = new ConsoleUserInteraction();

    ICookbook cookbook = new CookieCookbook(repository, ui);
try
{
    var result = cookbook.MakeNewRecipe();
}
catch (Exception e)
{
    //Log and close the application gracefully
    Console.WriteLine($"{e}");
}

