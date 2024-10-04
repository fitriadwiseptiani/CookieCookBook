using CookieCookbook.Enums;

namespace CookieCookbook.Container
{
    public interface IngredientBase
    {
        public int Id { get; }
        public IngredientName IngredientName { get; }
        public List<Instruction> Instructions { get; }
    }
}


