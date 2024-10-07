using CookieCookbook.Container;

namespace CookieCookbook.Repository
{
    public interface IRecipeBase
    {
        public int Id { get; }
        public List<IIngredientBase> IngredientBases { get;}
    }
}


