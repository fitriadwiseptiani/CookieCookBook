using CookieCookbook.Enums;

namespace CookieCookbook.Container.IngredientContainer.IngredientName;

public class Sugar : Ingredient
{
    public Sugar(int id, Enums.IngredientName ingredientName, List<Instruction> instructions) : base(id, Enums.IngredientName.Sugar, instructions)
    {
    }

}
