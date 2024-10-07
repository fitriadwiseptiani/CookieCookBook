using CookieCookbook.Enums;

namespace CookieCookbook.Container.IngredientContainer.IngredientName;

public class Cardamon : Ingredient
{
    public Cardamon(int id, Enums.IngredientName ingredientName, List<Instruction> instructions) : base(id, ingredientName, instructions)
    {
    }
}
