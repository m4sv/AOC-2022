using System.Collections;

public class Day3
{
    public static void Part1()
    {
        var inputStream = new StreamReader("inputs/03.txt");
        var line = inputStream.ReadLine();
        int prioritySum = 0;
        while (!string.IsNullOrWhiteSpace(line))
        {
            var compartment1 = line.Substring(0, line.Length / 2);
            var compartment2 = line.Substring(line.Length / 2, line.Length / 2);
            var matchingItem = compartment1.Intersect(compartment2).FirstOrDefault();

            prioritySum += GetPriority(matchingItem);
            line = inputStream.ReadLine();
        }
        Console.WriteLine(prioritySum);
    }

    public static void Part2()
    {
        var inputStream = new StreamReader("inputs/03.txt");
        bool loop = true;
        var prioritySum = 0;
        while (loop)
        {
            var line1 = inputStream.ReadLine();
            var line2 = inputStream.ReadLine();
            var line3 = inputStream.ReadLine();
            var matchingItem = line1.Intersect(line2).Intersect(line3).FirstOrDefault();
            prioritySum += GetPriority(matchingItem);
            if (inputStream.Peek() == -1) loop = false;
        }

        Console.WriteLine(prioritySum);
    }

    static int GetPriority(char item)
    {
        if (item >= 65 && item <= 90) return item - 65 + 27;
        else if (item >= 97 && item <= 122) return item - 96;
        return 0;
    }
}
