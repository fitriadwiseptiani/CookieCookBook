using System.ComponentModel.DataAnnotations;
using CookieCookbook.Classes;
using CookieCookbook.Interface;

namespace CookieCookbook.Controller;

public class CookieController
{
    private IIngredient _ingredient;
    private List<IIngredient> _ingredientList;
    private List<IRecipe> _recipeList;

    public CookieController(IIngredient ingredient){
        _ingredient = ingredient;
        _ingredientList = new List<IIngredient>();
        _recipeList = new List<IRecipe>();
    }
    public void AddIngredients(IIngredient ingredient){
        _ingredientList.Add(ingredient);
    }
    public Ingredient GetAllIngredients(){
        return (Ingredient)_ingredient;
    }
    public List<IIngredient> GetIngredientsList(){
        return _ingredientList;
    }
    public List<IRecipe> GetRecipeList()
    {
        return _recipeList;
    }
    public string GetRecipeId(IRecipe recipe){
        var foundRecipe = _recipeList.FirstOrDefault(r => r.RecipeId == recipe.RecipeId);
        if(!(foundRecipe == null)){
            return foundRecipe.RecipeId.ToString();
        }
        throw new Exception();
    }
    public string GetIngredientId(IIngredient ingredient){
        var foundIngredient = _ingredientList.FirstOrDefault(r => r.Id == ingredient.Id);
        if (!(foundIngredient == null))
        {
            return foundIngredient.Id.ToString();
        }
        throw new Exception();
    }

    public string GetIngredientName(IIngredient ingredient){
        var foundIngredient = _ingredientList.FirstOrDefault(r => r.IngredientName == ingredient.IngredientName);
        if (!(foundIngredient == null))
        {
            return foundIngredient.IngredientName.ToString();
        }
        throw new Exception();
    }

    public string GetInstructions(IIngredient ingredient){
        var foundIngredient = _ingredientList.FirstOrDefault(r => r.Instructions == ingredient.Instructions);
        if (!(foundIngredient == null))
        {
            return foundIngredient.Instructions.ToString();
        }
        throw new Exception();
    }

    public string GetRecipeDetails()
    {
        throw new NotImplementedException();
    }

    public static string GetEnumDisplayName(Enum value)
    {
        var displayAttribute = value.GetType()
            .GetMember(value.ToString())
            .FirstOrDefault()
            ?.GetCustomAttributes(typeof(DisplayAttribute), false)
            .FirstOrDefault() as DisplayAttribute;

        return displayAttribute?.Name ?? value.ToString(); // Kembalikan nama atau nama enum itu sendiri jika tidak ada
    }

}
