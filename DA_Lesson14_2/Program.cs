// Lists to store the spending names and costs
using System.Text.RegularExpressions;
var filename = "C:/TESTING/spending.txt";

List<string> spendingName = new List<string>();
List<double> spendingCost = new List<double>();
List<string> spendingNameCost = new List<string>();
double totalSpending = 0;

// Read the spendings from the file
if (File.Exists(filename))
{
    using (var streamReader = new StreamReader(filename))
    {
        string line;
        while ((line = streamReader.ReadLine()) != null)
        {
            // Check if the line is the sum line and skip it
            if (line.StartsWith("Total Spending:"))
                continue;

            spendingNameCost.Add(line);

            // Split the line to extract the cost and add it to the spendingCost list
            string[] parts = line.Split(':');
            if (parts.Length == 2)
            {
                spendingName.Add(parts[0].Trim());
                double cost = double.Parse(parts[1].Trim());
                spendingCost.Add(cost);

                // Add to total spending
                totalSpending += cost;
            }
        }
    }

}

while (true)
{
    Console.WriteLine("Please input the spending and money amount separated by a colon (e.g.,'Rent:1000,Food:250').");

    // Get the raw input from the user
    string rawInput = Console.ReadLine();

    if (rawInput.ToLower() == "stop")
        break;

    string nameOfSpending = Regex.Replace(rawInput, ":.*", "").Trim();
    double costOfSpending;

    try
    {
        costOfSpending = double.Parse(Regex.Replace(rawInput, ".*?:", "").Trim());
    }
    catch (System.FormatException)
    {
        Console.WriteLine("Invalid input format.");
        continue;
    }
    // Add the name and cost to their respective lists
    spendingName.Add(nameOfSpending);
    spendingCost.Add(costOfSpending);

    //Combined list of spendings
    string spendingCombined = $"{nameOfSpending}:{costOfSpending}";
    spendingNameCost.Add(spendingCombined);

    // Calculate the sum of all spendings
    totalSpending += costOfSpending;

    // Display the list of spendings
    Console.WriteLine("\nList of spendings:");
    foreach (string spend in spendingNameCost)
    {
        Console.WriteLine(spend);
    }
    Console.WriteLine($"Total Spending:{totalSpending}");
}

// Clean and re-write the spendings to the file
using (var streamWriter = new StreamWriter(filename))
{ }
using (var streamWriter = new StreamWriter(filename, true))
{
    foreach (string spend in spendingNameCost)
    {
        streamWriter.WriteLine(spend);
    }
    streamWriter.WriteLine($"Total Spending: {totalSpending}");
}

