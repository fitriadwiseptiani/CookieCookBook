using CookieCookbook.Enums;

namespace CookieCookbook.Container
{
    public class Ingredient : IngredientBase
    {
        public int Id { get; private set; }

        public IngredientName IngredientName { get; private set; }

        public List<Instruction> Instructions { get; private set; }
        private List<Ingredient> _ingredient;

        public override int GetIngredientById(Ingredient ingredient)
        {
            if (_ingredient.Contains(ingredient))
            {
                return ingredient.Id;
            }
            throw new Exception();
        }
        public override void SetIngredient(List<Ingredient> ingredients)
        {
            _ingredient = ingredients;
        }
        public Ingredient(int id, IngredientName ingredientName, List<Instruction> instructions)
        {
            Id = id;
            IngredientName = ingredientName;
            Instructions = instructions;
        }
    }
}


