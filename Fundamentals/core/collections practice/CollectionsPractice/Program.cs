/******************Arrays******************/
// Create an array to hold integer values 0 through 9
int [] arr = {0,1,2,3,4,5,6,7,8,9} ;

// int[] arr = new int[10];
//     for (int i = 0; i < arr.Length; i++)
//         {
//             arr[i] = i;
//         }

//Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
string [] arr1 = {"Tim", "Martin", "Nikki","Sara"};

//Create an array of length 10 that alternates between true and false values, starting with true
bool[] arr2 = new bool[10];
    for (int i = 0; i < arr2.Length; i++)
        {
            arr2[i] = i % 2 == 0;
        }
    
    // foreach (bool val in arr2)
    //     {
    //         Console.Write(val);
    //     }

/******************Lists******************/
//Create a list of ice cream flavors that holds at least 5 different flavors
List<string> flavors = new List<string>();
flavors.Add("Vanilla");
flavors.Add("Caramel");
flavors.Add("Strawberry");
flavors.Add("Chocolate");
flavors.Add("Orange");

Console.WriteLine($" length of Ice cream flavors list  : {flavors.Count}");
Console.WriteLine(flavors[2]);
flavors.RemoveAt(2);
Console.WriteLine($" The new length of Ice cream flavors list : {flavors.Count}");

/******************Dictionary******************/

//Create a dictionary that will store both string keys as well as string values
Dictionary<string,string> Dict = new Dictionary <string,string>();

// Add key/value pairs to this dictionary where:
//each key is a name from your names array
//each value is a randomly selected flavor from your flavors list.

Random FlavorRand = new Random();
foreach (string name in arr1)
    {
        int FlavorIndex = FlavorRand.Next(flavors.Count);
        string Flavor = flavors[FlavorIndex];
        Dict[name] = Flavor;
    }
//Loop through the dictionary and print out each user's name and their associated ice cream flavor
foreach (var entry in Dict)
    {
        Console.WriteLine($"Name: {entry.Key} Favorite Flavor: {entry.Value}");
    }

