using CookieCookbook.Container;
using CookieCookbook.Container.IngredientContainer.IngredientName;
using CookieCookbook.Enums;
using CookieCookbook.Container.IngredientContainer;
using CookieCookbook.RecipeData;
using CookieCookbook.Repository;

class Program
{
    private static List<IIngredientBase> ingredient = new List<IIngredientBase>();
    private static IRecipeBase recipeBase = new Recipe(1, ingredient, ingredientContainer);
    private static IngredientContainer ingredientContainer = new();

    static void Main()
    {

        CreateIngredient();

        List<IRecipeBase> recipes = new();
        IStringRepoManager stringRepoManager;


        Console.WriteLine("Choose format to save recipes: 1. JSON 2. TXT");
        int choice = int.Parse(Console.ReadLine());

        string filePath;

        if (choice == 1)
        {
            stringRepoManager = new JsonBasedStringRepo(ingredientContainer);
            filePath = "./File/recipes.json";
        }
        else
        {
            stringRepoManager = new TxtBaseStringRepo(ingredientContainer);
            filePath = "./File/recipes.txt";
        }

        RecipeRepo recipeRepo = new RecipeRepo(stringRepoManager, filePath, ingredientContainer);

        if (recipes.Count != null)
        {
            recipeRepo.PrintAllRecipe();
        }
        else
        {
            Console.WriteLine("Sorry there is no recipe can be selected. Please make new recipe");

        }
        Start();
        while (true)
        {
            ChooseAction(out int action);
            if (action == 2)
            {
                if (ingredient.Count > 0)
                {
                    Finished();
                }
                else
                {
                    Console.WriteLine("Sorry there is no ingredient selected, so you can not to make new recipe");

                }
                break;
            }
            else if (action == 1)
            {
                ChooseIngredient();

                Console.Write("\nChoose one of the ingredient by number (only input the number) : ");
                string inputPlayer = Console.ReadLine();


                RecipeFactory recipeFactory = new(1, ingredient, ingredientContainer);
                recipeFactory.MakeNewRecipe(inputPlayer, ingredient);

            }
        }
        if (ingredientContainer.GetIngredientsList().Count > 0)
        {

            recipeRepo.SaveRecipe(recipeBase);
        }
        else
        {
            Console.WriteLine("No ingredients selected. No recipe added.");

        }
    }
    static void CreateIngredient()
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
    static void Start()
    {
        Console.WriteLine("Hello welcome to our kitchen, let's make some food ^_^\n");
    }
    static void Finished()
    {
        Console.WriteLine("The session has been finished. Thank you for your contribution to adding new recipe");
    }
}

