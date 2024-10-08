using Cookbook.Model;

namespace Cookbook.App;

public interface IUserInteraction
{
    void WriteMessage(string message);
    int TryRead();
    List<Ingredient> GetIngredientsList();
    int GetIngredientById(Ingredient ingredient);
    string GetIngredientName(Ingredient ingredient);
    string GetIgredientInstruction(Ingredient ingredient);
    IEnumerable<Recipe> GetRecipesList();
}
