namespace CookieCookbook.Interface;

public interface IRecipe
{
    public int RecipeId { get; }
    List<IIngredient> Ingredients { get; }
}
