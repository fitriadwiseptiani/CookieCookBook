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

        // RecipeManager recipeManager = new RecipeManager(recipes);
        IRecipe recipe = new Recipe(1, cookie.GetIngredientsList());
        IRecipePrint recipePrinter = new RecipePrinter();
        recipeManager = new RecipeManager(recipePrinter);
        List<IIngredient> selectedIngredient = new();
        InitializeIngredient();

        recipeManager.PrintAllRecipe(cookie);
        while (true)
        {
            ChooseAction(out int action);
            if (action == 2)
            {
                Finished();
                break;
            }
            else if (action == 1)
            {
                ChooseIngredient();

                Console.Write("Choose one of the ingredient by number (only input the number) : ");
                string inputPlayer = Console.ReadLine();

                if (Int32.TryParse(inputPlayer, out int id))
                {
                    IIngredient ingredient = cookie.GetIngredientsList().Find(a => a.Id == id);
                    if (!(ingredient == null))
                    {
                        cookie.GetIngredientsList().Add(ingredient);
                        Console.WriteLine($"{ingredient.IngredientName} waas added to recipe");
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
        SaveRecipeIfAny();



    }
    static void SaveRecipeIfAny()
    {
        if (cookie.GetIngredientsList().Count > 0)
        {
            recipeManager.SaveRecipe(cookie.GetIngredientsList());
            Console.WriteLine("Recipe Added");
        }
        else
        {
            Console.WriteLine("No ingredients selected. No recipe added.");
        }
    }
    static void InitializeIngredient()
    {
        List<IIngredient> ingredients = new List<IIngredient>
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
        foreach (var ingredient in ingredients)
        {
            cookie.AddIngredients(ingredient);
        }
    }

    static void DisplayIngredient()
    {
        var ingredients = cookie.GetIngredientsList();
        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"{ingredient.Id}-{ingredient.IngredientName}");
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
            Console.WriteLine();
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


    // static List<IIngredient> ingredients = new List<IIngredient>{
    //         new Ingredient(1, NameIngredient.WheatFlour, new List<Instruction>{Instruction.Sieve, Instruction.AddIngredients}),
    //         new Ingredient(2, NameIngredient.CoconutFlour, new List<Instruction>{Instruction.Sieve, Instruction.AddIngredients}),
    //         new Ingredient(3, NameIngredient.Butter, new List<Instruction>{Instruction.MeltLowheat, Instruction.AddIngredients}),
    //         new Ingredient(4, NameIngredient.Chocolate, new List<Instruction>{Instruction.MeltWaterBath, Instruction.AddIngredients}),
    //         new Ingredient(5, NameIngredient.Sugar, new List<Instruction>{Instruction.AddIngredients}),
    //         new Ingredient(6, NameIngredient.Cardamon, new List<Instruction>{Instruction.TakeHalfTeaSpoon, Instruction.AddIngredients}),
    //         new Ingredient(7, NameIngredient.Cinnamon, new List<Instruction>{Instruction.TakeHalfTeaSpoon, Instruction.AddIngredients}),
    //         new Ingredient(8, NameIngredient.CocoaPowder, new List<Instruction>{Instruction.AddIngredients}),
    //     };
    // static void Main()
    // {


    //     List<IIngredient> selectedIngredient = new();

    //     while (true)
    //     {
    //         // Console.WriteLine("Input name : ");
    //         // string name = Console.ReadLine();

    //         // Console.WriteLine($"Hai, {name} let`s make some recipe for our cookie !!!");

    //         PrintAllRecipe();

    //         ChooseAction(out int action);
    //         if (action == 2)
    //         {
    //             Finished();
    //             break;
    //         }
    //         else if (action == 1)
    //         {
    //             ChooseIngredient(ingredients);

    //             Console.Write("Choose one of the ingredient by number (only input the number) : ");
    //             string inputPlayer = Console.ReadLine();

    //             if (Int32.TryParse(inputPlayer, out int id))
    //             {
    //                 IIngredient ingredient = ingredients.Find(a => a.Id == id);
    //                 if (!(ingredient == null))
    //                 {
    //                     selectedIngredient.Add(ingredient);
    //                     Console.WriteLine($"{ingredient.IngredientName} waas added to recipe");
    //                 }
    //                 else
    //                 {
    //                     Console.WriteLine("Please input the valid number. no ingredient was matched with id that you input");
    //                 }

    //             }
    //             else
    //             {
    //                 Console.WriteLine("Invalid input. Please input a number.");
    //             }
    //         }
    //     }
    //     if (selectedIngredient.Count > 0)
    //     {
    //         SaveRecipe(selectedIngredient);
    //         Console.WriteLine("Recipe Added");
    //     }
    //     else
    //     {
    //         Console.WriteLine("No ingredients selected. No recipe added.");
    //     }
    // }

    // static void ChooseAction(out int action)
    // {
    //     action = 0;
    //     bool validInput = false;

    //     while (!validInput)
    //     {
    //         Console.WriteLine("\nPlease choose one of this following action ");
    //         Console.WriteLine("1. Add Ingredient");
    //         Console.WriteLine("2. End Session");
    //         Console.WriteLine();
    //         Console.Write("Your Input : ");
    //         Console.WriteLine();
    //         bool status = int.TryParse(Console.ReadLine(), out int input);
    //         if (status && input >= 1 && input <= 2)
    //         {
    //             action = input;
    //             validInput = true;
    //         }
    //         else
    //         {
    //             Console.WriteLine("Please input valid number (1-2)");
    //             Thread.Sleep(1000);
    //         }
    //     }
    // }
    // static void ChooseFile()
    // {
    //     List<IIngredient> ingredientSave = new();
    //     Console.WriteLine("Before start, please select one of the file types below : ");
    //     Console.WriteLine("1. TXT");
    //     Console.WriteLine("2. JSON");
    //     Console.WriteLine();
    //     Console.Write("Your Input : ");
    //     string input = Console.ReadLine();
    //     if (input == "1")
    //     {

    //     }
    //     else if (input == "2")
    //     {
    //         string result = JsonSerializer.Serialize(ingredientSave); ;

    //         using (StreamWriter sw = new("./recipe.json"))
    //         {
    //             sw.WriteLine(result);
    //         }
    //     }
    // }
    // static void ChooseIngredient(List<IIngredient> chooseIngredients)
    // {
    //     Console.WriteLine("\nChoose one of the ingredient below : ");
    //     foreach (var ingredient in chooseIngredients)
    //     {
    //         Console.WriteLine($"{ingredient.Id}- {ingredient.IngredientName.ToString()}");
    //     }
    // }
    // static void SaveRecipe(List<IIngredient> ingredientsSave)
    // {
    //     // disimpan ke dalam bentuk txt atau json
    //     // string result = JsonSerializer.Serialize(ingredientsSave);
    //     // using (StreamWriter sw = new("./recipe.json", true))
    //     // {
    //     //     // foreach(var ingredient in ingredientsSave){
    //     //     //     sw.WriteLine($"{ingredient.Id}");
    //     //     // }

    //     //     sw.Write(result);
    //     // }
    //     if (ingredientsSave.Count == 0)
    //     {
    //         Console.WriteLine("No ingredients selected. Recipe will not be saved.");
    //         return;
    //     }


    //     // List<Ingredient> ingredientIds = new();
    //     // ingredientsSave.Add(ingredientIds);
    //     // foreach (var ingredient in ingredientsSave)
    //     // {
    //     //     ingredientIds.Add(ingredient.Id);
    //     // }

    //     // List<int> ingredientIds = new List<int>();
    //     // foreach (var ingredient in ingredientsSave)
    //     // {
    //     //     ingredientIds.Add(ingredient.Id);
    //     // }

    //     // string recipeLine = string.Join(",", ingredientIds);
    //     // string result = JsonSerializer.Serialize(ingredientIds);
    //     // string filePath = "recipes.json";
    //     // using (StreamWriter writer = new StreamWriter(filePath, true))
    //     // {
    //     //     writer.WriteLine(result);
    //     // }

    //     // Console.WriteLine("Recipe saved: " + recipeLine);
    //     List<int> ingredientIds = ingredientsSave.Select(i => i.Id).ToList();
    //     string recipeLine = string.Join(",", ingredientIds);

    //     string filePath = "recipes.json";
    //     List<string> recipes;

    //     if (File.Exists(filePath))
    //     {
    //         string json = File.ReadAllText(filePath);
    //         recipes = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
    //     }
    //     else
    //     {
    //         recipes = new List<string>();
    //     }

    //     recipes.Add(recipeLine);
    //     // int nextId = recipes.Count > 0 ? recipes.Max(r => r.RecipeId) + 1 : 1;
    //     // Recipe newRecipe = new Recipe(nextId, ingredientsSave);
    //     // recipes.Add(newRecipe);

    //     string serializedJson = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
    //     File.WriteAllText(filePath, serializedJson);

    //     Console.WriteLine("Recipe saved: " + recipeLine);

    // }
    // static void PrintAllRecipe()
    // {
    //     Console.WriteLine("Resep yang telah dibuat adalah sebagai berikut :");
    //     // string result;

    //     // using (StreamReader sr = new("./recipes.json"))
    //     // {
    //     //     result = sr.ReadToEnd();
    //     // }
    //     // List<Ingredient> ingredients = JsonSerializer.Deserialize<List<Ingredient>>(result);
    //     // foreach (var listRecipe in ingredients)
    //     // {
    //     //     Console.WriteLine($"***** {listRecipe.Id} *****");
    //     //     Console.Write($"{listRecipe.IngredientName}-");
    //     //     foreach (var instruction in listRecipe.Instructions)
    //     //     {
    //     //         Console.Write($"{instruction}.");
    //     //     }
    //     // }
    //     string filePath = "recipes.json";
    //     if (!File.Exists(filePath))
    //     {
    //         Console.WriteLine("No recipes found.");
    //         return;
    //     }

    //     string json = File.ReadAllText(filePath);
    //     List<string> recipes = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();

    //     Console.WriteLine("\nAll Recipes:");
    //     for (int i = 0; i < recipes.Count; i++)
    //     {
    //         string recipe = recipes[i];
    //         List<int> ingredientIds = recipe.Split(',').Select(int.Parse).ToList();
    //         Console.WriteLine($"Recipe {i + 1}:");
    //         foreach (int id in ingredientIds)
    //         {
    //             IIngredient ingredient = ingredients.Find(a => a.Id == id);
    //             if (ingredient != null)
    //             {
    //                 Console.WriteLine($"- {ingredient.IngredientName}: {string.Join(", ", ingredient.Instructions)}");
    //             }
    //         }
    //     }
    // }
    // static void Finished()
    // {
    //     Console.WriteLine("The session has been finished. Thank you for your contribution to adding new recipe");
    //     Console.WriteLine("Press any key to close it");
    // }
}
