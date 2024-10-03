using CookieCookbook.Container;

namespace CookieCookbook.Repository
{
    public class Recipe : RecipeBase
    {
        public List<Ingredient> Ingredients { get; set; }

        public override void MakeNewRecipe(string inputPlayer)
        {
            if (Int32.TryParse(inputPlayer, out int id))
                {
                    Ingredient ingredient = Ingredients.Find(a => a.Id == id);
                    if (!(ingredient == null))
                    {
                        Ingredients.Add(ingredient);
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
            // Console.WriteLine("Selected ingredients IDs: " + string.Join(", ", ingredients.Select(i => i.Id)));
            // List<int> ingredientIds = ingredients.Select(i => i.Id).ToList();
            // string recipeLine = string.Join(",", ingredientIds);
            
            // List<string> recipes;
            // recipes = new List<string>();
            // recipes.Add(recipeLine);

            // if (ingredients.Count == 0)
            // {
            //     Console.WriteLine("No ingredients selected. Recipe will not be saved.");
            //     return;
            // }
            // Console.WriteLine("Selected ingredients IDs: " + string.Join(", ", Ingredients.Select(i => i.Id)));
        }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }

    }
}

