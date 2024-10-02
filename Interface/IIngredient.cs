using CookieCookbook.Enums;

namespace CookieCookbook.Interface
{
    public interface IIngredient
    {
        public int Id { get; }
        NameIngredient IngredientName { get; }
        List<Instruction> Instructions { get; }
    }
}


