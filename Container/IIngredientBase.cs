using CookieCookbook.Enums;

namespace CookieCookbook.Container
{
    public interface IIngredientBase
    {
        int Id { get; }
        IngredientName IngredientName { get; }
        List<Instruction> Instructions { get; }
        Instruction BaseInstruction {get; }
    }
}


