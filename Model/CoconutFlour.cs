namespace Cookbook.Model;

public class CoconutFlour : Ingredient
{
    public override int Id => 2;

    public override string Name => "Coconut Flour";
    public override string InstructionPreparation => $"Sieve. {base.InstructionPreparation}";

}
