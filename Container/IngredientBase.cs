using CookieCookbook.Enums;

namespace CookieCookbook.Container
{
    public abstract class IngredientBase
    {
        public int Id { get; }
        public IngredientName IngredientName { get; }
        public List<Instruction> Instructions { get; }
        public abstract int GetIngredientById(Ingredient ingredient);
        public abstract void SetIngredient(List<Ingredient> ingredients);
    }
}


