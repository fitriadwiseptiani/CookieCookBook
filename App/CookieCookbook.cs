using Cookbook.Enums;
using Cookbook.Model;

namespace Cookbook.App;

public class CookieCookbook : ICookbook
{
    //Avalilable Ingredients
    private readonly List<Ingredient> _ingredient;

    //Recipes
    private readonly IEnumerable<Recipe> _recipes;

    //User Interaction
    private readonly IUserInteraction _ui;

    //Recipe Repository
    private readonly IRecipeRepository _recipeRepository;

    //Dependency Injection & Inverison
    public CookieCookbook(IEnumerable<Recipe> recipes, IRecipeRepository recipeRepository, IUserInteraction ui)
    {
        _ingredient = new List<Ingredient>();
        _recipes = recipes;
        _recipeRepository = recipeRepository;
        _ui = ui;
    }
    public CookbookErrorCode MakeNewRecipe()
    {
        while (true)
        {
            ChooseIngredient();
            _ui.WriteMessage("\nChoose one of the ingredient by number (only input the number) : ");
            string inputPlayer = Console.ReadLine();
            if (Int32.TryParse(inputPlayer, out int id))
            {
                Ingredient ingredient = _ingredient.Find(a => a.Id == id);
                if (_ingredient != null)
                {
                    _ingredient.Add(ingredient);
                    _ui.WriteMessage($"{ingredient.Name} was added to recipe");
                }
                else
                {
                    _ui.WriteMessage("Please input the valid number. no ingredient was matched with id that you input");
                    ChooseIngredient();
                }

            }

            SavingRecipe();
            return CookbookErrorCode.NoError;
        }
    }
    public void DisplayIngredient()
    {
        _ui.WriteMessage("\n Available Ingredient : ");
        var ingredients = _ui.GetIngredientsList();
        foreach (var ingredient in ingredients)
        {
            _ui.WriteMessage($"{ingredient.Id} - {ingredient.Name}");
        }
    }
    public void ChooseAction()
    {
        bool validInput = false;
        while (!validInput)
        {
            _ui.WriteMessage("\nPlease choose one of this following action ");
            _ui.WriteMessage("1. Add Ingredient");
            _ui.WriteMessage("2. End Session");
            _ui.WriteMessage("");
            _ui.WriteMessage("Your Input : ");
            _ui.WriteMessage("");
            bool status = int.TryParse(Console.ReadLine(), out int input);
            if (status && input == 1)
            {
                ChooseIngredient();
                validInput = true;
            }
            else if (status && input == 2)
            {
                if (_ingredient.Count > 0)
                {
                    Finished();
                    validInput = true;
                }
                ChooseIngredient();
            }
            else
            {
                _ui.WriteMessage("Please input valid number (1-2)");
                Thread.Sleep(1000);
            }
        }
    }
    public void ChooseIngredient()
    {
        _ui.WriteMessage("\nChoose one of the ingredient below : ");
        DisplayIngredient();
    }
    public void Finished()
    {
        _ui.WriteMessage("The session has been finished. Thank you for your contribution to adding new recipe");
    }
    public void SavingRecipe(){
        if (_ingredient.Count > 0)
        {
            
            _recipeRepository.SaveRecipes(recipe);
        }
        else
        {
            Console.WriteLine("No ingredients selected. No recipe added.");

        }
    }

}
