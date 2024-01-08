// Challenge 1
//bool amProgrammer = "true";
bool amProgrammer = true ;

//int Age = 27.9;
int Age = 27; 

List<string> Names = new List<string>();
//Names = "Monica";
Names.Add("Monica");
Dictionary<string, string> MyDictionary = new Dictionary<string, string>();
MyDictionary.Add("Hello", "0");

//MyDictionary.Add("Hi there", 0);
MyDictionary.Add("Hi there", "0");
// This is a tricky one! Hint: look up what a char is in C#
//string MyName = 'MyName';
string MyName = "MyName";

// Challenge 2
Console.WriteLine("Challenge 2");
List<int> Numbers = new List<int>() {2,3,6,7,1,5};
//for(int i = Numbers.Count; i >= 0; i--) 
//Index was out of range
for(int i = Numbers.Count-1; i >= 0; i--)
{
    Console.WriteLine(Numbers[i]);
}
// Challenge 3
Console.WriteLine("Challenge 3");
List<int> MoreNumbers = new List<int>() {12,7,10,-3,9};
foreach(int i in MoreNumbers)
{
    //Console.WriteLine(MoreNumbers[i]);
    Console.WriteLine(MoreNumbers);
}
// Challenge 4
Console.WriteLine("Challenge 4");
List<int> EvenMoreNumbers = new List<int> {3,6,9,12,14};
// foreach(int num in EvenMoreNumbers)
// {
//     if(num % 3 == 0)
//     {
//         num = 0;
//     }
// }
for(int num= 0; num< EvenMoreNumbers.Count; num++)
{
    if(EvenMoreNumbers[num] % 3 == 0)
    {
        EvenMoreNumbers[num]  = 0;
        //Console.WriteLine(EvenMoreNumbers[num]);
    }
    
}
// Challenge 5
Console.WriteLine("Challenge 5");
// What can we learn from this error message?
string MyString = "superduberawesome";
// MyString[7] = "p"; the string is read only 
//Console.WriteLine(MyString[7]);

// Challenge 6
Console.WriteLine("Challenge 6");
// Hint: some bugs don't come with error messages
// Random rand = new Random();
// int randomNum = rand.Next(12);
// if(randomNum == 12)
// {
//     Console.WriteLine("Hello");
// }
Random rand = new Random();
int randomNum = rand.Next(13); 
 Console.WriteLine(randomNum);

if(randomNum == 12) // will never be true because the random will only generate values between 0 and 11(rand.Next(13)) 
{
    Console.WriteLine("Hello");
    Console.WriteLine(randomNum);
}

