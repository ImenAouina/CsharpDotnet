public class Samurai : Human
{
    //Samurai should have a default health of 200
     public Samurai(string name, int str, int intel, int dex, int hp) : base(name, str, intel, dex,200)
    {      
    }
//Provide an override Attack method to Samurai, which calls the base Attack 
//and reduces the target's health to 0 if it has less than 50 remaining health points.
     public override int Attack(Human target)
    {
        int dmg = Strength * 3;
        if (dmg < 50) 
        {
            target.Health = 0;
        }
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        Console.WriteLine($"Health: {target.Health} SamuraiHealth {Health} Intelligence: {Intelligence}");
        return target.Health;
    }
    //Samurai should have a method called Meditate, which when invoked, heals the Samurai back to full health
    public void Mediate()
    {
        Console.WriteLine($"SamuraiHealth {Health} ");
        Health=200;
    }
}