using CookieCookbook.Controller;
using CookieCookbook.Interface;

namespace CookieCookbook.Classes;

public class RecipePrinter : IRecipePrint
{
    public string PrintRecipe(CookieController cookie, List<int> ingredientIds)
    {
        List<string> ingredientDetails = new List<string>();

        foreach (int id in ingredientIds)
        {
            IIngredient ingredient = cookie.GetIngredientsList().Find(a => a.Id == id);
            if (ingredient != null)
            {
                ingredientDetails.Add($"{ingredient.IngredientName}. {string.Join(". ", ingredient.Instructions)}");
            }
        }

        return string.Join("\n", ingredientDetails);
    }
        

    }
