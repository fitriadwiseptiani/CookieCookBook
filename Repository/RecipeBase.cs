using CookieCookbook.Container;

namespace CookieCookbook.Repository
{
    public abstract class RecipeBase
    {
        public List<Ingredient> Ingredients { get;}
        public abstract void MakeNewRecipe(string inputPlayer);

    }
}


