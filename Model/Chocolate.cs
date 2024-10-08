namespace Cookbook.Model;

public class Chocolate : Ingredient
{
    public override int Id => 4;

    public override string Name => "Chocolate";
    public override string InstructionPreparation => $"Melt in  water bath. {base.InstructionPreparation}";  

}
