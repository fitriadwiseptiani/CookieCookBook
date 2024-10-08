namespace Cookbook.Model;

public class Cinnamon : Ingredient
{
    public override int Id => 7;

    public override string Name => "Cinnamon";
    public override string InstructionPreparation => $"Take a half a teaspoon. {base.InstructionPreparation}";

}
