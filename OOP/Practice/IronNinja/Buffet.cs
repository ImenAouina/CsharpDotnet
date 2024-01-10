class Buffet
{
    //public List<Food> Menu;  
    public List<IConsumable> Menu;
    //constructor
    public Buffet()
    {
        Menu = new List<IConsumable>()
        {
            new Food("Food1", 1000, false, false),
            new Food("Food2", 1300, false, false),
            new Food("Food3", 5000, true, false),
            new Drink("Drink1", 550, false, true),
            new Drink("Drink2", 350, true, true),
            new Drink("Drink3", 750, false, true),
            new Drink("Drink4", 2900, true, true)

        };
        //Console.WriteLine(Menu);
    }    
    public IConsumable Serve()
    {
        Random rand = new Random ();
        int index = rand.Next(Menu.Count);
        return Menu[index];

    }
}