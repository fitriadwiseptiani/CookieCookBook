using System.Diagnostics;
using System.Text.Json;
using CookieCookbook.Container;
using CookieCookbook.Container.IngredientContainer;
using CookieCookbook.Enums;
using CookieCookbook.RecipeData;

namespace CookieCookbook.Repository
{
    public class RecipeRepo
    {
        private IStringRepoManager _stringRepoManager;
        private readonly string _filePath;
        private List<IRecipeBase> _recipes;
        private IngredientContainer _ingredientContainer;

        public RecipeRepo(IStringRepoManager stringRepoManager, string filePath, IngredientContainer ingredientContainer)
        {
            _stringRepoManager = stringRepoManager;
            _filePath = filePath;
            _ingredientContainer = ingredientContainer;
        }
        public void SaveRecipe(IRecipeBase recipe)
        {
            if (recipe.IngredientBases.Count == 0)
            {
                Console.WriteLine("No ingredients selected. Recipe will not be saved.");
                return;
            }
            Console.WriteLine("Selected ingredients: " + string.Join(", ", recipe.IngredientBases.Select(i => i.Id)));

            List<int> ingredientIds = recipe.IngredientBases.Select(i => i.Id).ToList();
            string recipeLine = string.Join(",", ingredientIds);

            _stringRepoManager.SaveRecipe(recipe, recipeLine);

        }

        public void PrintAllRecipe()
        {
            _stringRepoManager.PrintAllRecipe();
            
        }

    }
}


