using System.ComponentModel.DataAnnotations;
using CookieCookbook.Classes;
using CookieCookbook.Interface;

namespace CookieCookbook.Controller;

public class CookieController
{
    private List<IIngredient> _ingredient;

    public CookieController(List<IIngredient> ingredients){
        _ingredient = ingredients;
    }
    public List<IIngredient> GetIngredientsList(){
        return _ingredient;
    }
    public void SetIngredient(List<IIngredient> ingredients)
	{
		_ingredient = ingredients;
	}

}
