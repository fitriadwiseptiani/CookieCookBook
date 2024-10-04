
using CookieCookbook.Enums;

namespace CookieCookbook.Container
{
    public class IngredientContainer
    {
        private List<IIngredientBase> _ingredientsBase { get; set; }

        public int GetIngredientById(IIngredientBase ingredientBase)
        {
            if (_ingredientsBase.Contains(ingredientBase))
            {
                return ingredientBase.Id;
            }
            throw new Exception();
        }
        public void SetIngredient(List<IIngredientBase> ingredientBase)
        {
            _ingredientsBase = ingredientBase;
        }
        public List<IIngredientBase> GetIngredientsList()
        {
            return _ingredientsBase;
        }
    }
}


