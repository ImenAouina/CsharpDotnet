List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

//Use LINQ to find the first eruption that is in Chile and print the result.
Eruption FirstChile = eruptions.FirstOrDefault(c => c.Location == "Chile");
Console.WriteLine($"the first eruption that is in Chile {FirstChile}");

//Find the first eruption from the "Hawaiian Is" location and print it. 
//If none is found, print "No Hawaiian Is Eruption found."
// bool HawaiianLocation = eruptions.Any(c => c.Location == "Hawaiian Is");
// if(HawaiianLocation == true)
// {
//     Console.WriteLine($"{HawaiianLocation}");
// }else{
//     Console.WriteLine($"No Hawaiian Is Eruption found");
// }

Eruption HawaiianLocation = eruptions.FirstOrDefault(c => c.Location == "Hawaiian Is");
if(HawaiianLocation == null)
{
    Console.WriteLine($"No Hawaiian Is Eruption found");
}else{
    Console.WriteLine($"the first eruption from the \"Hawaiian Is\" location:{HawaiianLocation}");
}

//Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Eruption eruptionAfter1900 = eruptions.FirstOrDefault(c => (c.Location == "New Zealand") && (c.Year > 1900));
Console.WriteLine($"the first eruption that is after the year 1900 AND in \"New Zealand\": {eruptionAfter1900}");

//Find all eruptions where the volcano's elevation is over 2000m and print them.
IEnumerable<Eruption> elevationOverThan2000 = eruptions.Where(c => c.ElevationInMeters > 2000);
PrintEach(elevationOverThan2000, "Eruptions where the volcano's elevation is over 2000m:");

//Find all eruptions where the volcano's name starts with "L" and print them. 
//Also print the number of eruptions found.

IEnumerable<Eruption> volcanosNameStartsWithL  = eruptions.Where(c => c.Volcano.StartsWith("L"));
int numberOfEruption = volcanosNameStartsWithL.Count();
PrintEach(volcanosNameStartsWithL, "Eruptions where the volcano's name starts with \"L\" ");
Console.WriteLine($"the number of eruptions where the volcano's name starts with \"L\" is: {numberOfEruption}");

//Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
Int32 highestElevation = eruptions.Max(c => c.ElevationInMeters);
Console.WriteLine($"the highest elevation Value is: {highestElevation}");

//Use the highest elevation variable to find a print the name of the Volcano with that elevation.

// IEnumerable<Eruption> volcanoWithHighestElevation = eruptions.Where(c => c.ElevationInMeters == 3320);
// List<string> volcanoName = volcanoWithHighestElevation.Select(n => n.Volcano).ToList();
// PrintEach(volcanoName,"Volcano with the highest elevation:");

List<string> volcanoName = eruptions.Where(c => c.ElevationInMeters == 3320).Select(n => n.Volcano).ToList();
PrintEach(volcanoName,"Volcano with the highest elevation:");

//Print all Volcano names alphabetically.
List<string> volcanoNamesAlphabetically = eruptions.OrderBy(c => c.Volcano).Select(n => n.Volcano).ToList();
PrintEach(volcanoNamesAlphabetically,"Volcano names alphabetically:");
 
//Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
IEnumerable<Eruption> eruptionBefore1000 = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano);
PrintEach(eruptionBefore1000, "All the eruptions that happened before the year 1000 CE alphabetically");

//BONUS: Redo the last query, but this time use LINQ to only select the volcano's name 
//so that only the names are printed.
List<string> bonus = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano).Select(n => n.Volcano).ToList();
PrintEach(bonus, "Bonus");


// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
