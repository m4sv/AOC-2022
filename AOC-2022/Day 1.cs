var inputStream = new StreamReader("inputs/01.txt");
var elves = new List<int>();
int currentElf = 0;

var line = inputStream.ReadLine();
while (line != null)
{
    if (line == String.Empty)
    {
        if (elves.Count == 0) elves.Add(currentElf);
        else if(elves[0] <= currentElf) elves.Insert(0, currentElf);
        currentElf = 0;
    }
    else
    {
        currentElf += int.Parse(line);
    }
    line = inputStream.ReadLine();
}

Console.WriteLine($"Most Calorific Elf: {elves[0]}");
Console.WriteLine($"Combined Top 3 Elf Calories: {elves[0] + elves[1] + elves[2]}");
