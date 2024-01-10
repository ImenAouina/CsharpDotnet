public class Ninja : Human
{
    //Ninja should have a default dexterity of 75
     public Ninja(string name, int str, int intel, int dex, int hp) : base(name, str, intel, 75,hp)
    {      
        //Dexterity=75;       
    }
    //Provide an override Attack method to Ninja, which reduces the target's health by their Dexterity amount 
    //and has a 20% chance of dealing an additional 10 points of damage.
     public override int Attack(Human target)
    {
        int dmg = Strength * 3;
        target.Health -= Dexterity;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        Console.WriteLine($"Health: {target.Health} Intelligence: {Intelligence} {Dexterity}");
        return target.Health;
    }
    //Ninja should have a method called Steal, reduces a target Human's health by 5 
    //and adds this amount to its own health
    public void Steal(Human target)
    {
         target.Health -= 5;
         Health += 5;
         Console.WriteLine($"HumanHealth: {target.Health} NinjaHealth: {Health}");
    }
}