using CookieCookbook.Controller;

namespace CookieCookbook.Interface;

public interface IRecipePrint
{
    string PrintRecipe(CookieController cookie, List<int> ingredientId);
}
