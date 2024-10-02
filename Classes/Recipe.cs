using CookieCookbook.Interface;

namespace CookieCookbook.Classes
{
    public class Recipe : IRecipe
    {
        public int RecipeId { get; set; }

        public List<IIngredient> Ingredients { get; set; }

        public Recipe(int recipeId, List<IIngredient> ingredients){
            RecipeId = recipeId;
            Ingredients = new List<IIngredient>();
        }


    }
}


