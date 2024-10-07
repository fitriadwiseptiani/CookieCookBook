using CookieCookbook.Enums;

namespace CookieCookbook.Container.IngredientContainer.IngredientName;

public class Chocolate : Ingredient
{
    public Chocolate(int id, Enums.IngredientName ingredientName, List<Instruction> instructions) : base(id, Enums.IngredientName.Chocolate, instructions)
    {
    }

}
