using System.Text.Json;
using CookieCookbook.Container;
using CookieCookbook.Container.IngredientContainer.IngredientName;
using CookieCookbook.Enums;
using CookieCookbook.IngredientContainer;
using CookieCookbook.Repository;

class Program
{
    private static List<IIngredientBase> ingredientBase = CreateIngredient();
    // private static IngredientContainer ingredientContainer = new IngredientContainer();
    // private static List<Ingredient> ingredientBase;

    static void Main()
    {
        CreateIngredient();
        // DisplayIngredient();
        List<Recipe> recipes = new();
        // IStringRepoManager stringRepoManager2 = new Txt();

        Console.WriteLine("Choose format to save recipes: 1. JSON 2. TXT");
        int choice = int.Parse(Console.ReadLine());

        IStringRepoManager stringRepoManager;
        string filePath;
        
        if (choice == 1)
        {
            stringRepoManager = new JsonBasedStringRepo();
            filePath = "./File/recipes.json";
        }
        else
        {
            stringRepoManager = new TxtBaseStringRepo();
            filePath = "./File/recipes.txt";
        }

        RecipeRepo recipeRepo = new RecipeRepo(stringRepoManager, filePath);

        // RecipeFactory recipeFactory = new(ingredientBase);

        // string fileFormat = ChooseFormatFile();

        // recipeRepo.PrintAllRecipe();

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
                if (ingredientBase.Count > 0)
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
                // IIngredientBase selectedIngredient = ingredientBase.FirstOrDefault(ingredient => ingredient.Id.ToString() == inputPlayer);

                // if (selectedIngredient != null)
                // {
                //     recipes.Add(new Recipe(recipes.Count + 1, new List<IIngredientBase> { selectedIngredient }));
                // }
                // else
                // {
                //     Console.WriteLine("Invalid selection. Try again.");
                // }
                Recipe newRecipe = Recipe.MakeNewRecipe(inputPlayer, ingredientBase);

                if (newRecipe.IngredientBases.Any())
                {
                    recipes.Add(newRecipe);
                }
                else
                {
                    Console.WriteLine("Invalid selection. Try again.");
                }

            }
        }
        if (recipes.Any())
        {
            foreach (var recipe in recipes)
            {
                recipeRepo.SaveRecipe(recipe);
            }
            Console.WriteLine("Recipes added.");
            recipeRepo.PrintAllRecipe();
        }
        else
        {
            Console.WriteLine("No ingredients selected. No recipe added.");

        }
    }
    static List<IIngredientBase> CreateIngredient()
    {
        return new List<IIngredientBase>
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
    }
    static void DisplayIngredient(List<IIngredientBase> ingredientBases)
    {
        // var ingredients = IngredientContainer.GetIngredientsList();
        for (int i = 0; i < ingredientBase.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {ingredientBase[i].IngredientName}.{string.Join(". ", ingredientBase[i].Instructions)}");
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
        DisplayIngredient(ingredientBase);
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

