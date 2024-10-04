
using CookieCookbook.Enums;

namespace CookieCookbook.Container{
    public class IngredientContainer : Ingredient
    {
        private List<Ingredient> _ingredients { get;  set; }
        public IngredientContainer(int id, IngredientName ingredientName, List<Instruction> instructions) : base(id, ingredientName, instructions)
        {
            _ingredients = new List<Ingredient>();
        }


        public override int GetIngredientById(Ingredient ingredient)
        {
            if (_ingredients.Contains(ingredient))
            {
                return ingredient.Id;
            }
            throw new Exception();
        }

        public override void SetIngredient(List<Ingredient> ingredient)
        {
            _ingredients = ingredient;
        }
    }
}


