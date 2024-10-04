using CookieCookbook.Container;

namespace CookieCookbook.Repository
{
    public abstract class Recipe : IRecipeBase
    {
        public List<IIngredientBase> IngredientBases { get; set; }
        
        public abstract void MakeNewRecipe(string inputPlayer, List<IIngredientBase> ingredients);
        public Recipe(List<IIngredientBase> ingredientBases){
            IngredientBases = ingredientBases;
        }
    }
}

