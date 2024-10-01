using CookieCookbook.Enums;
using CookieCookbook.Interface;

namespace CookieCookbook.Classes
{
    public class Ingredient : IIngredient
    {
        public int Id {get; private set;}

        public NameIngredient IngredientName {get; private set;}

        public List<Instruction> Instructions {get; private set;}

        public Ingredient(int id, NameIngredient ingredientName, List<Instruction> instructions){
            Id = id;
            IngredientName = ingredientName;
            Instructions = instructions;
        }
        public string GetIngredientName(){
            return IngredientName.ToString();
        }
    }
}


