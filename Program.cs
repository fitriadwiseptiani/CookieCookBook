using System.Text.Json;
using CookieCookbook.Container;
using CookieCookbook.Enums;
using CookieCookbook.Repository;

class Program
{
    private static List<Ingredient> ingredients = new List<Ingredient>();
    static void Main()
    {
        CreateIngredient();
        DisplayIngredient();
        List<Recipe> recipes = new();
        Recipe recipe = new();
        
        // RecipeRepo recipeRepo = new(recipes);

        string fileFormat = ChooseFormatFile();
        RecipeRepo recipeRepo = new(fileFormat);

        recipeRepo.PrintAllRecipe(recipes);
        
        while (true)
        {
            // ChooseFormatFile(out int input);
            // if (input == 2)
            // {
            //     recipeRepo.PrintAllRecipeWithJson(recipeRepo);
            //     recipeRepo.SaveRecipeToJson();

            // }
            // else if (input == 1)
            // {
            //     CreateIngredient();
            //     DisplayIngredient();
            // }
            ChooseAction(out int action);
            if (action == 2)
            {
                if (ingredients.Count > 0)
                {
                    Finished();
                }
                else
                {
                    return;
                }
                break;
            }
            else if (action == 1)
            {
                ChooseIngredient();

                Console.Write("\nChoose one of the ingredient by number (only input the number) : ");
                string inputPlayer = Console.ReadLine();

                recipe.MakeNewRecipe(inputPlayer);

                

            }
        }
        if (ingredients.Count > 0)
        {
            recipeRepo.SaveRecipe();
            Console.WriteLine("Recipe Added");
        }
        else
        {
            Console.WriteLine("No ingredients selected. No recipe added.");

        }
    }
    static void CreateIngredient()
    {
        ingredients.AddRange(new List<Ingredient>
        {
            new Ingredient(1, IngredientName.WheatFlour, new List<Instruction>{Instruction.Sieve, Instruction.AddIngredients}),
            new Ingredient(2, IngredientName.CoconutFlour, new List<Instruction>{Instruction.Sieve, Instruction.AddIngredients}),
            new Ingredient(3, IngredientName.Butter, new List<Instruction>{Instruction.MeltLowheat, Instruction.AddIngredients}),
            new Ingredient(4, IngredientName.Chocolate, new List<Instruction>{Instruction.MeltWaterBath, Instruction.AddIngredients}),
            new Ingredient(5, IngredientName.Sugar, new List<Instruction>{Instruction.AddIngredients}),
            new Ingredient(6, IngredientName.Cardamon, new List<Instruction>{Instruction.TakeHalfTeaSpoon, Instruction.AddIngredients}),
            new Ingredient(7, IngredientName.Cinnamon, new List<Instruction>{Instruction.TakeHalfTeaSpoon, Instruction.AddIngredients}),
            new Ingredient(8, IngredientName.CocoaPowder, new List<Instruction>{Instruction.AddIngredients}),
        });
    }
    static void DisplayIngredient()
    {
        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Id} - {ingredient.IngredientName}");
        }
    }
    static void ChooseAction(out int action)
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

    static void ChooseIngredient()
    {
        Console.WriteLine("\nChoose one of the ingredient below : ");
        DisplayIngredient();
    }
    static string ChooseFormatFile()
    {
        string fileFormat = "";
        bool validInput = false;
        Console.Write("\nChoose the format film for save the recipe : ");
        Console.WriteLine("1. Json");
        Console.WriteLine("2. Txt");
        Console.WriteLine();
        Console.Write("Your Input : ");
        Console.WriteLine("");
        bool status = int.TryParse(Console.ReadLine(), out int input);
        if (status && input == 1 && input == 2)
        {
            fileFormat = input == 1 ? "json" : "txt";
            validInput = true;
        }
        else
        {
            Console.WriteLine("Please input valid number (1-2)");
            Thread.Sleep(1000);
        }
        return fileFormat;
    }
    static void Finished()
    {
        Console.WriteLine("The session has been finished. Thank you for your contribution to adding new recipe");
    }
}

