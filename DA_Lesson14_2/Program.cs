// Lists to store the spending names and costs
using System.Text.RegularExpressions;
var filename = "C:/TESTING/spending.txt";

List<string> spendingName = new List<string>();
List<double> spendingCost = new List<double>();
List<string> spendingNameCost = new List<string>();

while (true)
{
    Console.WriteLine("Please input the spending and money amount separated by a colon (e.g.,'Rent:1000,Food:250').");

    // Get the raw input from the user
    string rawInput = Console.ReadLine();

    if (rawInput.ToLower() == "stop")
        break;

    string nameOfSpending = Regex.Replace(rawInput, ":.*", "").Trim();
    string costOfSpending = Regex.Replace(rawInput, ".*?:", "").Trim();

    // Add the name and cost to their respective lists
    spendingName.Add(nameOfSpending);
    spendingCost.Add(double.Parse(costOfSpending));

    //Combined list of spendings

     string spendingCombined = $"{nameOfSpending}:{costOfSpending}";
     spendingNameCost.Add(spendingCombined);
    
    // Display the list of spendings
    Console.WriteLine("\nList of spendings:");

    foreach (string spend in spendingNameCost)
    {
        Console.WriteLine(spend);
    }
}
// Write the spendings to the file
using (var streamWriter = new StreamWriter(filename, true))
    {
        foreach (string spend in spendingNameCost)
        {
            streamWriter.WriteLine(spend);
        }
    }

