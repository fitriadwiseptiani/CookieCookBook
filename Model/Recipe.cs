
using Cookbook.Model;

namespace Cookbook.App;

public class Recipe
{
    public List<Ingredient> _ingredients;  
    public Recipe(List<Ingredient> ingredients){
        _ingredients = ingredients;
    } 
}
