class Card 
{
    string Name;
    string suit;
    int val;

    public void print() 
    {
        Console.WriteLine($"{Name}-{suit}-{val}");
    }
}