class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory;
     
    // add a constructor
    public Ninja ()
    {
        calorieIntake=0;
        FoodHistory= new List<Food>();

    }
     
    // add a public "getter" property called "IsFull"
    public bool IsFull ()
    {
        if (calorieIntake>1200)
            return true;   
        else 
            return false;
    }
     
    // build out the Eat method 
    public void Eat(Food item)
    {
        bool isfull = IsFull();
        if (isfull == false)
        {
            calorieIntake += item.Calories;
            FoodHistory.Add(item);
            if(item.IsSpicy)
            Console.WriteLine($"Name: {item.Name} is spicy");
            if(item.IsSweet)
            Console.WriteLine($"Name: {item.Name} is sweet");
        }
        else 
        {
            Console.WriteLine("Ninja is full");
        }
    }
}


