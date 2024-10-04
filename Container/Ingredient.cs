using CookieCookbook.Enums;

namespace CookieCookbook.Container
{
    public class Ingredient : IIngredientBase
    {
        public int Id { get; private set; }

        public IngredientName IngredientName { get; private set; }

        public List<Instruction> Instructions { get; private set; }

        public Instruction BaseInstruction => Instruction.AddIngredients;

        // public abstract int GetIngredientById(Ingredient ingredient);
        // public abstract void SetIngredient(List<Ingredient> ingredient);

        public Ingredient(int id, IngredientName ingredientName, List<Instruction> instructions)
        {
            Id = id;
            IngredientName = ingredientName;
            Instructions = instructions;
            Instructions.Add(BaseInstruction);
        }
    }
}


