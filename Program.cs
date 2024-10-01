using System.Text.Json;
using CookieCookbook.Classes;
using CookieCookbook.Enums;
using CookieCookbook.Interface;

class Program
{
    // private List<IIngredient> _ingredients;
    static void Main()
    {
        List<IIngredient> ingredients = new List<IIngredient>{
            new Ingredient(1, NameIngredient.WheatFlour, new List<Instruction>{Instruction.Sieve, Instruction.AddIngredients}),
            new Ingredient(2, NameIngredient.CoconutFlour, new List<Instruction>{Instruction.Sieve, Instruction.AddIngredients}),
            new Ingredient(3, NameIngredient.Butter, new List<Instruction>{Instruction.MeltLowheat, Instruction.AddIngredients}),
            new Ingredient(4, NameIngredient.Chocolate, new List<Instruction>{Instruction.MeltWaterBath, Instruction.AddIngredients}),
            new Ingredient(5, NameIngredient.Sugar, new List<Instruction>{Instruction.AddIngredients}),
            new Ingredient(6, NameIngredient.Cardamon, new List<Instruction>{Instruction.TakeHalfTeaSpoon, Instruction.AddIngredients}),
            new Ingredient(7, NameIngredient.Cinnamon, new List<Instruction>{Instruction.TakeHalfTeaSpoon, Instruction.AddIngredients}),
            new Ingredient(8, NameIngredient.CocoaPowder, new List<Instruction>{Instruction.AddIngredients}),
        };

        List<IIngredient> selectedIngredient = new();

        while (true)
        {
            // Console.WriteLine("Input name : ");
            // string name = Console.ReadLine();

            // Console.WriteLine($"Hai, {name} let`s make some recipe for our cookie !!!");

            ChooseAction(out int action);
            switch (action)
            {
                case 1:
                    ChooseIngredient(ingredients);

                    Console.Write("Choose one of the ingredient by number (only input the number) : ");
                    string inputPlayer = Console.ReadLine();

                    if (Int32.TryParse(inputPlayer, out int id))
                    {
                        IIngredient ingredient = ingredients.Find(a => a.Id == id);
                        if (!(ingredient == null))
                        {
                            selectedIngredient.Add(ingredient);

                        }
                        else
                        {
                            Console.WriteLine("Please input the valid number");
                        }
                    }
                    if (selectedIngredient.Count > 0)
                    {
                        SaveRecipe(selectedIngredient);
                        Console.WriteLine("Recipe Added");
                    }
                    break;

                case 2:
                    Finished();
                    break;
            }
            break;
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
        static void ChooseFile()
        {
            List<IIngredient> ingredientSave = new();
            Console.WriteLine("Before start, please select one of the file types below : ");
            Console.WriteLine("1. TXT");
            Console.WriteLine("2. JSON");
            Console.WriteLine();
            Console.Write("Your Input : ");
            string input = Console.ReadLine();
            if (input == "1")
            {

            }
            else if (input == "2")
            {
                string result = JsonSerializer.Serialize(ingredientSave); ;

                using (StreamWriter sw = new("./recipe.json"))
                {
                    sw.WriteLine(result);
                }
            }
        }
        static void ChooseIngredient(List<IIngredient> chooseIngredients)
        {
            Console.WriteLine("\nChoose one of the ingredient below : ");
            foreach (var ingredient in chooseIngredients)
            {
                Console.WriteLine($"{ingredient.Id}- {ingredient.IngredientName.ToString()}");
            }
        }
        static void SaveRecipe(List<IIngredient> ingredientsSave)
        {
            // disimpan ke dalam bentuk txt atau json

            string result = JsonSerializer.Serialize(ingredientsSave); ;

            using (StreamWriter sw = new("./recipe.json"))
            {
                sw.WriteLine(result);
            }
        }
        static void PrintAllRecipe(List<IIngredient> printRecipe)
        {
            Console.WriteLine("Resep yang telah dibuat adalah sebagai berikut :");
            foreach (var recipe in printRecipe)
            {
                Console.WriteLine($"***** {recipe.Id} *****");

            }

        }
        static void Finished()
        {
            Console.WriteLine("The session has been finished. Thank you for your contribution to adding new recipe");
            Console.WriteLine("Press any key to close it");
        }
    }
}