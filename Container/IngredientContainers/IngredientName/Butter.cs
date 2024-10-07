using CookieCookbook.Enums;

namespace CookieCookbook.Container.IngredientContainer.IngredientName;

public class Butter : Ingredient
{
    public Butter(int id, Enums.IngredientName ingredientName, List<Instruction> instructions) : base(id, ingredientName, instructions)
    {
    }
}
