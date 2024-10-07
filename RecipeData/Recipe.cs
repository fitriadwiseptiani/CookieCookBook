using CookieCookbook.Container;
using CookieCookbook.Container.IngredientContainer;

namespace CookieCookbook.RecipeData
{
    public class Recipe : IRecipeBase
    {
        public int Id { get; set; }
        public List<IIngredientBase> IngredientBases { get; set; }
        public IngredientContainer _ingredientContainer;

        public Recipe(int id, List<IIngredientBase> ingredientBases, IngredientContainer ingredientContainer)
        {
            Id = id;
            IngredientBases = ingredientBases;
        }
        
    }
}

