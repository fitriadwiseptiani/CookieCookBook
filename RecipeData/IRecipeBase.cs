using CookieCookbook.Container;

namespace CookieCookbook.RecipeData
{
    public interface IRecipeBase
    {
        int Id { get; }
        List<IIngredientBase> IngredientBases { get;}
    }
}


