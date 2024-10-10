namespace Cookbook.Model;

public class Cardamon : Ingredient
{
    public override int Id => 6;

    public override string Name => "Cardamon";
    public override string InstructionPreparation => $"Take half a teaspoon. {base.InstructionPreparation}";

}
