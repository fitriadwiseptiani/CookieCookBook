using CookieCookbook.Enums;

namespace CookieCookbook.Container.IngredientContainer.IngredientName;

public class WheatFlour : Ingredient
{
    public WheatFlour(int id, Enums.IngredientName ingredientName, List<Instruction> instructions) : base(id, Enums.IngredientName.WheatFlour, instructions)
    {
    }

}
