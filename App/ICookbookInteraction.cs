using Cookbook.App.Repository;
using Cookbook.Enums;
using Cookbook.Model;

namespace Cookbook.App;

public interface ICookbookInteraction
{
    List<Ingredient> GetIngredientsList();
    void DisplayIngredient();
    void ChooseAction(out int action);
    void ChooseIngredient();
    IStringRepoManager ChooseFormat();
    void Finished();
    void RecipeStatus(CookbookErrorCode result);
    void GetSelectedIngredients(Recipe recipe);
    List<string> LoadFileJson(string filePath);
    List<string> LoadFileTxt(string filePath);
    string PrintSingleRecipe(List<int> ingredientIds);
    void DisplayRecipe(List<string> recipe);
}
