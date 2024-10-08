namespace Cookbook.Model;

public class Butter : Ingredient
{
    public override int Id => 3;

    public override string Name => "Butter";
    public override string InstructionPreparation => $"Melt in a low heat. {base.InstructionPreparation}";
}
