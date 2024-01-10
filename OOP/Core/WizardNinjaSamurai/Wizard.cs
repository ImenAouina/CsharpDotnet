public class Wizard : Human
{
    
    //Wizard should have a default health of 50 and Intelligence of 25
     public Wizard(string name, int str, int intel, int dex, int hp) : base(name, str, 25, dex,50)
    {      
        Health=50;
        Intelligence=25;
    
    }
    //Provide an override Attack method to Wizard, which reduces the target's health by 3 * Intelligence
    // and heals the Wizard by the amount of damage dealt
     public override int Attack(Human target)
    {
        int dmg = Intelligence * 3;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        Console.WriteLine($"Health: {Health} Intelligence: {Intelligence}");
        return target.Health;

    }
    //Wizard should have a method called Heal, which when invoked, heals a target Human by 3 * Intelligence
    public void Heal(Human target)
    {
        target.Health*=3;
        Console.WriteLine("Health:"+target.Health);
    }
}