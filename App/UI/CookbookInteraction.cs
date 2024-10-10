using System.Text.Json;
using Cookbook.App.Repository;
using Cookbook.Enums;
using Cookbook.Model;

namespace Cookbook.App.UI;

public class CookbookInteraction : ICookbookInteraction
{
    private List<Ingredient> _ingredient;
    private readonly IUserInteraction _ui;
    IStringRepoManager _stringRepoManager;
    public CookbookInteraction()
    {
        _ingredient = new List<Ingredient>
        {
            new WheatFlour(),
            new CoconutFlour(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamon(),
            new Cinnamon(),
            new CocoaPowder(),
        };
        _ui = new ConsoleUserInteraction();
    }
    public List<Ingredient> GetIngredientsList()
    {
        return _ingredient;
    }
    public void DisplayIngredient()
    {
        _ui.WriteMessage("\n Available Ingredient : ");
        var ingredients = GetIngredientsList();
        foreach (var ingredient in ingredients)
        {
            _ui.WriteMessage($"{ingredient.Id} - {ingredient.Name}");
        }
    }
    public void ChooseAction(out int action)
    {
        action = 0;
        bool validInput = false;
        while (!validInput)
        {
            _ui.WriteMessage("\nPlease choose one of this following action ");
            _ui.WriteMessage("1. Add Ingredient");
            _ui.WriteMessage("2. End Session");
            _ui.WriteMessage("");
            _ui.WriteMessage("Your Input : ");
            bool status = _ui.TryRead(Console.ReadLine(), out int input);
            if (status && input >= 1 && input <= 2)
            {
                action = input;
                validInput = true;
            }
            else
            {
                _ui.WriteMessage("Please input valid number (1-2)");
                Thread.Sleep(1000);
            }
        }
    }
    public void ChooseIngredient()
    {
        _ui.WriteMessage("\nChoose one of the ingredient below : ");
        DisplayIngredient();
    }
    public IStringRepoManager ChooseFormat()
    {
        _ui.WriteMessage("Choose format to save recipes: 1. JSON 2. TXT");
        int choice = int.Parse(Console.ReadLine());

        string filePath;

        if (choice == 1)
        {
            _stringRepoManager = new JsonBasedStringRepo();
        }
        else
        {
            _stringRepoManager = new TxtBasedStringRepo();
        }
        return _stringRepoManager;
    }
    public void Finished()
    {
        _ui.WriteMessage("The session has been finished. Thank you for your contribution to adding new recipe");
    }
    public void RecipeStatus(CookbookErrorCode result)
    {
        if (result == CookbookErrorCode.NoError)
        {
            _ui.WriteMessage("Recipe created successfully.");
        }
        else
        {
            _ui.WriteMessage($"An error occurred: {result}");
        }
    }
    public void GetSelectedIngredients(Recipe recipe)
    {
        if (recipe._ingredients.Count == 0)
        {
            _ui.WriteMessage("No ingredients selected. Recipe will not be saved.");
        }

        _ui.WriteMessage("Selected ingredients: " + string.Join(", ", recipe._ingredients.Select(i => i.Id).Distinct()));
    }
    public List<string> LoadFileJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            _ui.WriteMessage("No recipes found.");
            return new List<string>();
        }
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
    }
    public List<string> LoadFileTxt(string filePath)
    {
        if (!File.Exists(filePath))
        {
            _ui.WriteMessage("No recipes found.");
            return new List<string>();
        }
        return File.ReadAllLines(filePath).ToList();
    }

    public string PrintSingleRecipe(List<int> ingredientIds)
    {
        List<string> ingredientDetails = new List<string>();
        foreach (int id in ingredientIds)
        {
            Ingredient ingredient = GetIngredientsList().Find(a => a.Id == id);
            if (ingredient != null)
            {
                _ui.WriteMessage($"{ingredient.Name}. {string.Join(". ", ingredient.InstructionPreparation)}");
            }
            else
            {
                _ui.WriteMessage($"Ingredient with ID {id} not found in recipe.");
            }
        }
        return string.Join("\n", ingredientDetails);
    }
    public void DisplayRecipe(List<string> recipe)
    {
        _ui.WriteMessage("\nAvailable Recipe : ");
        recipe.Select((recipeData, index) => new { recipeData, index })
           .ToList()
           .ForEach(r =>
           {
               List<int> ingredientIds = r.recipeData.Split(',').Select(int.Parse).ToList();
               _ui.WriteMessage($"***** Recipe {r.index + 1} *****");
               _ui.WriteMessage(PrintSingleRecipe(ingredientIds));
           });
    }

}
