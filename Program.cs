using System.Text.Json;
using CookieCookbook.Classes;
using CookieCookbook.Controller;
using CookieCookbook.Enums;
using CookieCookbook.Interface;

class Program
{
    private static CookieController cookie;
    private static RecipeManager recipeManager;
    static void Main(string[] args)
    {
        cookie = new CookieController(null);
        List<IIngredient> selectedIngredient = new();
        IRecipe recipe = new Recipe(1, selectedIngredient);
        IRecipePrint recipePrinter = new RecipePrinter();
        recipeManager = new RecipeManager(recipePrinter);
        InitializeIngredient();

        recipeManager.PrintAllRecipe(cookie);

        while (true)
        {
            ChooseAction(out int action);
            if (action == 2)
            {
                if(selectedIngredient.Count > 0){
                    Finished();
                }
                else{
                    return;
                }
                break;
            }
            else if (action == 1)
            {
                ChooseIngredient();

                Console.Write("\nChoose one of the ingredient by number (only input the number) : ");
                string inputPlayer = Console.ReadLine();

                if (Int32.TryParse(inputPlayer, out int id))
                {
                    IIngredient ingredient = cookie.GetIngredientsList().Find(a => a.Id == id);
                    if (!(ingredient == null))
                    {
                        selectedIngredient.Add(ingredient);
                        Console.WriteLine($"{ingredient.IngredientName} was added to recipe");
                    }
                    else
                    {
                        Console.WriteLine("Please input the valid number. no ingredient was matched with id that you input");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input. Please input a number.");
                }
            }
        }
        if (cookie.GetIngredientsList().Count > 0)
        {
            recipeManager.SaveRecipe(selectedIngredient);
            Console.WriteLine("Recipe Added");
        }
        else
        {
            Console.WriteLine("No ingredients selected. No recipe added.");
            
        }
    }
    static void InitializeIngredient()
    {
        var ingredients = new List<IIngredient>
        {
            new Ingredient(1, NameIngredient.WheatFlour, new List<Instruction>{Instruction.Sieve, Instruction.AddIngredients}),
            new Ingredient(2, NameIngredient.CoconutFlour, new List<Instruction>{Instruction.Sieve, Instruction.AddIngredients}),
            new Ingredient(3, NameIngredient.Butter, new List<Instruction>{Instruction.MeltLowheat, Instruction.AddIngredients}),
            new Ingredient(4, NameIngredient.Chocolate, new List<Instruction>{Instruction.MeltWaterBath, Instruction.AddIngredients}),
            new Ingredient(5, NameIngredient.Sugar, new List<Instruction>{Instruction.AddIngredients}),
            new Ingredient(6, NameIngredient.Cardamon, new List<Instruction>{Instruction.TakeHalfTeaSpoon, Instruction.AddIngredients}),
            new Ingredient(7, NameIngredient.Cinnamon, new List<Instruction>{Instruction.TakeHalfTeaSpoon, Instruction.AddIngredients}),
            new Ingredient(8, NameIngredient.CocoaPowder, new List<Instruction>{Instruction.AddIngredients}),
        };
        cookie.SetIngredient(ingredients);
    }

    static void DisplayIngredient()
    {
        var ingredients = cookie.GetIngredientsList();
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
    
    static void Finished()
    {
        Console.WriteLine("The session has been finished. Thank you for your contribution to adding new recipe");
    }
}
