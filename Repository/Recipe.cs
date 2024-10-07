using CookieCookbook.Container;

namespace CookieCookbook.Repository
{
    public class Recipe : IRecipeBase
    {
        public int Id { get; set; }
        public List<IIngredientBase> IngredientBases { get; set; }

        public Recipe(int id, List<IIngredientBase> ingredientBases)
        {
            Id = id;
            IngredientBases = ingredientBases;
        }

        public static Recipe MakeNewRecipe(string input, List<IIngredientBase> ingredientBase)
        {
            List<IIngredientBase> selectedIngredients = new List<IIngredientBase>();

            var ingredientIds = input.Split(',').Select(int.Parse).ToList();

            foreach (var id in ingredientIds)
            {
                var ingredient = ingredientBase.FirstOrDefault(i => i.Id == id);
                if (ingredient != null)
                {
                    selectedIngredients.Add(ingredient);
                }
            }

            int newId = new Random().Next(1000, 9999); // Generating a new ID. You might want to use a better ID generation strategy.
            return new Recipe(newId, selectedIngredients);
        }
    }
}

