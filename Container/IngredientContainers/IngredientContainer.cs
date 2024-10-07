
using CookieCookbook.Container;
using CookieCookbook.Enums;

namespace CookieCookbook.Container.IngredientContainer
{
    public class IngredientContainer
    {
        private List<IIngredientBase> _ingredientsBase { get; set; }
        public void SetIngredient(List<IIngredientBase> ingredientBase)
        {
            _ingredientsBase = ingredientBase;
        }
        public List<IIngredientBase> GetIngredientsList()
        {
            return _ingredientsBase ?? new List<IIngredientBase>();
        }
    }
}


