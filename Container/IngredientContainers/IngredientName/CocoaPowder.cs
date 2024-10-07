using CookieCookbook.Enums;

namespace CookieCookbook.Container.IngredientContainer.IngredientName;

public class CocoaPowder : Ingredient
{
    public CocoaPowder(int id, Enums.IngredientName ingredientName, List<Instruction> instructions) : base(id, ingredientName, instructions)
    {
    }
}
