using System.ComponentModel;

namespace CookieCookbook.Enums;

public enum Instruction
{
    [Description("Sieve")]
    Sieve,

    [Description("Melt on low heat")]
    MeltLowheat,

    [Description("Melt in a water bath")]
    MeltWaterBath,

    [Description("Add to other ingredients")]
    AddIngredients,

    [Description("Take half a teaspoon")]
    TakeHalfTeaSpoon

}
