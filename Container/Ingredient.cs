using CookieCookbook.Enums;

namespace CookieCookbook.Container
{
    public abstract class Ingredient : IngredientBase
    {
        public int Id { get; private set; }

        public IngredientName IngredientName { get; private set; }

        public List<Instruction> Instructions { get; private set; }
        public abstract int GetIngredientById(Ingredient ingredient);
        public abstract void SetIngredient(List<Ingredient> ingredients);

        public Ingredient(int id, IngredientName ingredientName, List<Instruction> instructions)
        {
            Id = id;
            IngredientName = ingredientName;
            Instructions = instructions;
        }
    }
}


