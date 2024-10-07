using CookieCookbook.Enums;

namespace CookieCookbook.Container.IngredientContainer.IngredientName;

public class CoconutFlour : Ingredient
{
    public CoconutFlour(int id, Enums.IngredientName ingredientName, List<Instruction> instructions) : base(id, Enums.IngredientName.CoconutFlour, instructions)
    {
    }

}
