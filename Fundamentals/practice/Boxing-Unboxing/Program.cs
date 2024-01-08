// Create an empty List of type object
List<object> myList = new List<object>();
//Add the following values to the list: 7, 28, -1, true, "chair"
myList.Add(7);
myList.Add(28);
myList.Add(-1);
myList.Add(true);
myList.Add("chair");
//Loop through the list and print all values
int sum=0;
foreach(var item in myList) 
{
    Console.WriteLine(item);
//Add all values that are Int type together and output the sum
    if(item is int)
    {
        sum += (int)item; 
    }   
}
Console.WriteLine($"the sum is: {sum}");
