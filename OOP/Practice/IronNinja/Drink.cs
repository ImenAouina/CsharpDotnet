class Drink : IConsumable
{
    public string Name {get;set;}
    public int Calories {get;set;}
    public bool IsSpicy {get;set;}
    public bool IsSweet {get;set;}
    
    // Implement a GetInfo Method
    public string GetInfo()
    {
        return $"{Name} (Food).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";
    }
    // Add a constructor method
    public Drink(string n, int c, bool sp, bool st)
    {
        Name= n;
        Calories= c;
        IsSpicy= sp;
        IsSweet= st;
    }
}   

