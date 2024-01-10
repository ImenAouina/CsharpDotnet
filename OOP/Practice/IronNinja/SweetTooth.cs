class SweetTooth : Ninja
{
    public SweetTooth():base()
    {
    }
    // provide override for IsFull (Full at 1500 Calories)
    public override bool IsFull 
    {
        get  
      {  
        if(calorieIntake >= 1500)
        {
            return true;
        } 
        return false;
      }
        
    }
    //adds calorie value to SweetTooth's total calorieIntake (+10 additional calories if the consumable item is "Sweet")
    //adds the randomly selected IConsumable object to SweetTooth's ConsumptionHistory list
    //calls the IConsumable object's GetInfo() method
    public override void Consume(IConsumable item)
    {
        // provide override for Consume
        if (IsFull==false)
        {
            ConsumptionHistory.Add(item);
            calorieIntake += item.Calories;
            
            if (item.IsSweet == true)
            {
                calorieIntake+=10;
            }
                string info = item.GetInfo();
                Console.WriteLine(info);
            
        }
        else
        {
            Console.WriteLine("warning: the SweetTooth is full and cannot eat anymore");
        }
    }
}

