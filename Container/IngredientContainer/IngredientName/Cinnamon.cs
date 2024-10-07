using CookieCookbook.Enums;

namespace CookieCookbook.Container.IngredientContainer.IngredientName;

public class Cinnamon : Ingredient
{
    public Cinnamon(int id, Enums.IngredientName ingredientName, List<Instruction> instructions) : base(id, Enums.IngredientName.Cinnamon, instructions)
    {
    }

}
