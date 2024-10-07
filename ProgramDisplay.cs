using CookieCookbook.Container;
using CookieCookbook.Container.IngredientContainer;
using CookieCookbook.Container.IngredientContainer.IngredientName;
using CookieCookbook.Enums;
using CookieCookbook.RecipeData;

namespace CookieCookbook
{
    public class Display
    {
        private static List<IIngredientBase> ingredient = new List<IIngredientBase>();
        private static IRecipeBase recipeBase = new Recipe(1, ingredient, ingredientContainer);
        private static IngredientContainer ingredientContainer = new();

        public void CreateIngredient()
        {
            var ingredients = new List<IIngredientBase>

        {
            new WheatFlour(1, IngredientName.WheatFlour, new List<Instruction>{Instruction.Sieve}),
            new CoconutFlour(2, IngredientName.CoconutFlour, new List<Instruction>{Instruction.Sieve}),
            new Butter(3, IngredientName.Butter, new List<Instruction>{Instruction.MeltLowheat}),
            new Chocolate(4, IngredientName.Chocolate, new List<Instruction>{Instruction.MeltWaterBath}),
            new Sugar(5, IngredientName.Sugar, new List<Instruction>()),
            new Cardamon(6, IngredientName.Cardamon, new List<Instruction>{Instruction.TakeHalfTeaSpoon}),
            new Cinnamon(7, IngredientName.Cinnamon, new List<Instruction>{Instruction.TakeHalfTeaSpoon}),
            new CocoaPowder(8, IngredientName.CocoaPowder, new List<Instruction>()),
        };
            ingredientContainer.SetIngredient(ingredients);
        }
        static void DisplayIngredient()
        {
            Console.WriteLine("\n Avalilable Ingredient : ");
            var ingredients = ingredientContainer.GetIngredientsList();
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Id} - {ingredient.IngredientName}");
            }
        }
        public void ChooseAction(out int action)
        {
            action = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("\nPlease choose one of this following action ");
                Console.WriteLine("1. Add Ingredient");
                Console.WriteLine("2. End Session");
                Console.WriteLine();
                Console.Write("Your Input : ");
                Console.WriteLine("");
                bool status = int.TryParse(Console.ReadLine(), out int input);
                if (status && input >= 1 && input <= 2)
                {
                    action = input;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Please input valid number (1-2)");
                    Thread.Sleep(1000);
                }
            }
        }

        public void ChooseIngredient()
        {
            Console.WriteLine("\nChoose one of the ingredient below : ");
            DisplayIngredient();
        }
        public void Finished()
        {
            Console.WriteLine("The session has been finished. Thank you for your contribution to adding new recipe");
        }

    }
}


