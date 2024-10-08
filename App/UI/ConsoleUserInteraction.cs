using Cookbook.Model;

namespace Cookbook.App;

public class ConsoleUserInteraction : IUserInteraction
{
    private List<Ingredient> _ingredient;
    private IEnumerable<Recipe> _recipes;
    public void WriteMessage(string message)
    {
        Console.WriteLine(message);
    }
    public int TryRead()
    {
        throw new NotImplementedException();
    }
    public List<Ingredient>  GetIngredientsList(){
        return _ingredient;
    }
    public int GetIngredientById(Ingredient ingredient){
        if(_ingredient.Contains(ingredient)){
            return ingredient.Id;
        }
        throw new Exception();
    }
    public string GetIngredientName(Ingredient ingredient){
        if(_ingredient.Contains(ingredient)){
            return ingredient.Name;
        }
        throw new Exception();
    }
    public string GetIgredientInstruction(Ingredient ingredient){
        if(_ingredient.Contains(ingredient)){
            return ingredient.InstructionPreparation;
        }
        throw new Exception();
    }
    public IEnumerable<Recipe> GetRecipesList(){
        return _recipes;
    }

}
