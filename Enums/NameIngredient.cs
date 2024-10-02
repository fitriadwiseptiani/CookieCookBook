using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CookieCookbook.Enums;

public enum NameIngredient
{
    [Display(Name ="Wheat Flour")]
    WheatFlour,

    [Display(Name = "Coconut Flour")]
    CoconutFlour,

    [Display(Name = "Butter")]
    Butter,

    [Display(Name = "Chocolate")]
    Chocolate,

    [Display(Name = "Sugar")]
    Sugar,

    [Display(Name = "Cardamon")]
    Cardamon,

    [Display(Name = "Cinnamon")]
    Cinnamon,

    [Display(Name = "Cocoa Powder")]
    CocoaPowder,
}
