namespace Cookbook.Model;

public abstract class Ingredient
{
    public abstract int Id {get;}
    public abstract string Name {get;}
    public virtual string InstructionPreparation => "Add to other ingredients";
}
