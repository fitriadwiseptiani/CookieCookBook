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
    public CookieCookbook(List<Ingredient> ingredient, IEnumerable<Recipe> recipes, IRecipeRepository recipeRepository, IUserInteraction ui){
        _ingredient = ingredient;
        _recipes = recipes;
        _recipeRepository = recipeRepository;
        _ui = ui;
    }
    public CookbookErrorCode MakeNewRecipe(string inputPlayer)
    {
        if(Int32.TryParse(inputPlayer, out int id)){
            Ingredient ingredient = _ui.GetIngredientsList().Contains(id);
            if(_ingredient != null){
                _ingredient.Add(ingredient);
                _ui.WriteMessage($"{ingredient.Name} was added to recipe");
            }
            else{
                _ui.WriteMessage("Please input the valid number. no ingredient was matched with id that you input");
            }

        }
        return CookbookErrorCode.NoError;
    }
    public void DisplayIngredient() {
        _ui.WriteMessage("\n Available Ingredient : ");
        var ingredients = _ui.GetIngredientsList();
        foreach(var ingredient in ingredients){
            _ui.WriteMessage($"{ingredient.Id} - {ingredient.Name}");
        }
    }
    public void ChooseAction(){
        bool validInput = false;
        while(!validInput){

        }
    }

}
