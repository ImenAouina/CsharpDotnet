class Buffet
{
    public List<Food> Menu;  
    //constructor
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Example", 1000, false, false),
            new Food("Example1", 1300, false, false),
            new Food("Example2", 5000, true, false),
            new Food("Example3", 550, false, true),
            new Food("Example4", 350, true, true),
            new Food("Example5", 750, false, true),
            new Food("Example6", 2900, true, true)

        };
        //Console.WriteLine(Menu);
    }    
    public Food Serve()
    {
        Random rand = new Random ();
        int index = rand.Next(Menu.Count);
        return Menu[index];

    }
}