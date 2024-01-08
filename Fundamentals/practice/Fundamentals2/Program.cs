//************Print 1-255 ***********//

static void PrintNumbers()
{
    // Print all of the integers from 1 to 255.
    for(int n=1 ; n<= 255 ; n++)
    Console.WriteLine(n);
}
PrintNumbers();

//************Print odd numbers between 1-255 ***********//
static void PrintOdds()
{
    // Print all of the odd integers from 1 to 255.
    for(int n=1 ; n<= 255 ; n++)
    if(n % 2 != 0) 
    {
     Console.WriteLine(n);
    }
}
PrintOdds();

//************Print Sum***********//

static void PrintSum()
{
    int sum = 0;
    // Print all of the numbers from 0 to 255, 
    // but this time, also print the sum as you go.
    // For example, your output should be something like this:
    // New number: 0 Sum: 0 
    for(int n=1 ; n<= 255 ; n++)
    {
    sum+=n;
    Console.WriteLine($" New number: {n} Sum: {sum}");
    }  
}
PrintSum();

//************Iterating through an Array***********//
static void LoopArray(int[] numbers)
{
    // Write a function that would iterate through each item of the given integer array and 
    // print each value to the console. 
    foreach(int num in numbers)
    {
        Console.WriteLine(num);
    }
}
/*int [] arr1= {1,2,3,2,1,3,6};
LoopArray(arr1);*/

/************************Find Max******************/
static int FindMax(int[] numbers)
{
    // Write a function that takes an integer array and prints and returns the maximum value in the array. 
    // Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), 
    // or even a mix of positive numbers, negative numbers and zero.
    int max = 0;
    for (int i=0 ; i< numbers.Length ; i++)
    {
        if (max < numbers[i])
        max = numbers[i];
    }
    return max;
}
int [] arr1= {-1,2,3,2,1,3,36754,6,-7,0,9,100};
int maximum = FindMax(arr1);
Console.WriteLine($"the maximum value in the array is: {maximum}");

/************************ Get Average******************/
static void GetAverage(int[] numbers)
{
    // Write a function that takes an integer array and prints the AVERAGE of the values in the array.
    // For example, with an array [2, 10, 3], your program should write 5 to the console.
    int sum = 0;
    int avg = 0;
    for (int i=0 ; i< numbers.Length ; i++)
    {
        sum += numbers[i];
    }
    avg= sum/numbers.Length;
    Console.WriteLine($"the Average of the values in the array is: {avg}");
}
int [] arr2= {200,100,400,200,100};
GetAverage(arr2);

/************************ List with odd numbers******************/

static List<int> OddList()
{
    // Write a function that creates, and then returns, a List that contains all the odd numbers between 1 to 255. 
    // When the program is done, the List should have the values of [1, 3, 5, 7, ... 255].
    List<int> IntList = new List<int>();
    for (int i=1; i<=255; i++ )
    {
        if(i%2 != 0)
        {
            IntList.Add(i);
        }
        
    }
   return IntList;
}

List<int> IntList1=OddList();
Console.WriteLine($"List contains all the odd numbers between 1 to 255:");
foreach(int num in IntList1)
{
    Console.WriteLine(num);
}


/************************ Greater than Y ******************/ 
static int GreaterThanY(List<int> numbers, int y)
{
    // Write a function that takes an integer List, and an integer "y" and returns the number of values 
    // That are greater than the "y" value. 
    // For example, if our List contains 1, 3, 5, 7 and y is 3. Your function should return 2 
    // (since there are two values in the List that are greater than 3).
    int numberofvalues = 0;
    foreach (int item in numbers)
    {
       if (item > y)
       {
            numberofvalues+=1;
       }
    }
    Console.WriteLine($"Number of values GreaterThan {y} is: {numberofvalues}");
    return numberofvalues;
    
}
List<int> list2 = new List<int>{-1,3,4,3,1,3,13,1,-2,4};
int numVal = GreaterThanY(list2, 1);
Console.WriteLine(numVal);

/******************Square the Values**************/
static void SquareArrayValues(List<int> numbers)
{
    // Write a function that takes a List of integers called "numbers", and then multiplies each value by itself.
    // For example, [1,5,10,-10] should become [1,25,100,100]
     for (int i=0; i< numbers.Count; i++)
     {
        numbers[i]*=numbers[i];
     }
}
/*SquareArrayValues(list2);
foreach(int num in list2)
{
    Console.WriteLine(num);
}*/

/******************Eliminate Negative Numbers************/
static void EliminateNegatives(List<int> numbers)
{
    // Given a List of integers called "numbers", say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. 
    // When the program is done, "numbers" should have no negative values, say [1, 5, 10, 0].
      for (int i=0; i< numbers.Count; i++)
    {
       if (numbers[i] < 0)
       {
            numbers[i] = 0;
       }
    }
}
EliminateNegatives(list2);
foreach(int num in list2)
{
    Console.WriteLine(num);
}













