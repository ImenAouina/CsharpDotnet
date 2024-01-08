/*************Random Array********/
using System.ComponentModel.DataAnnotations;

static int[] RandomArray()
{
    //Create an empty array that will hold 10 integer values.
    int [] arr = new int[10];
    //Loop through the array and assign each index a random integer value between 5 and 25.
    Random rand = new Random();
    for (int i=0; i<10; i++)
    {
        arr[i]= rand.Next(5,25);
    }
    //Print the min, max and the sum of all the values
    int max= arr[0];
    int min= arr[0];
    int sum = 0;
    for (int i=0; i<10; i++)
    {
        sum+=arr[i];
        if (max < arr[i])
            max= arr[i];
        if (min > arr[i])
            min= arr[i];
    }
    Console.WriteLine($"Max:{max} Min:{min} Sum:{sum}");
    return arr;
}
int [] arr1 = RandomArray();
foreach(int n in arr1)
{
    Console.WriteLine(n);
}

/*************Coin Flip required********/
static string TossCoin()
{
    //Have the function print "Tossing a Coin!"
   // Console.WriteLine("Tossing a Coin!");

    //Randomize a coin toss with a result signaling either side of the coin
    Random random = new Random();
    int result = random.Next(2);

    //Have the function print either "Heads" or "Tails"
    string HeadsOrTails = (result == 0) ? "Heads" : "Tails";
    //Console.WriteLine(HeadsOrTails);
    return HeadsOrTails;
}

string res = TossCoin();
Console.WriteLine("the result is: "+res);

/*************Coin Flip Optional ********/
static double TossMultipleCoins(int num) 
{
    //Have the function call the tossCoin function multiple times based on num value
    int headToss = 0;
    for(int i=0; i<num; i++)
    {
        string ress=TossCoin();
        //Console.WriteLine(ress);
        if (ress == "Heads")
        {
            headToss+=1;
            
        }       
        
    }
    //Have the function return a Double that reflects the ratio of head toss to total toss
    Console.WriteLine($"head toss :{headToss}");
    Console.WriteLine($"total toss :{num}");
    double ratio = (double)headToss/num;
    return ratio;
}
double result= TossMultipleCoins(20);
Console.WriteLine($"the ratio of head toss to total toss is: {result}");

/************Names***************/
//++++++++Required++++++++//
//function Names that returns a list of strings
//Create a list with the values: Todd, Tiffany, Charlie, Geneva, Sydney
static List<string> Names()
{
    List<string> namesList = new List<string> {"Todd", "Tiffany", "Charlie","Amelie", "Geneva", "Sydney"};
    List<string> namesListFiveChar = new List<string>();
    //Return a list that only includes names longer than 5 characters
    for(int i=0; i<namesList.Count; i++)
    {
        if(namesList[i].Length > 5)
        {
            namesListFiveChar.Add(namesList[i]);
        }
    }
    return namesListFiveChar;
}
List<string> ListRes = Names();
Console.WriteLine("list of Names longer than 5 characters:");
foreach(string name in ListRes) 
{
    Console.WriteLine(name);
}

//++++++++Optional++++++++//
//Shuffle the list and print the values in the new order

 static void ShuffleList(List<string> listToShuffle)
    {
        Random random = new Random();
        //List<string> listToShuffle = Names();
        int n = listToShuffle.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int index = random.Next(0, i + 1);

            string temp = listToShuffle[i];
            listToShuffle[i] = listToShuffle[index];
            listToShuffle[index] = temp;
        }
    }
Console.WriteLine("Shuffled List");
ShuffleList(ListRes);
//Alphabetic order 
ListRes.Sort();
foreach(string name in ListRes) 
{
    Console.WriteLine(name);
}


