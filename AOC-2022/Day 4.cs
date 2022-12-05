using System.Collections;

public class Day4
{
    public static void Part1()
    {
        var inputStream = new StreamReader("inputs/04.txt");
        var line = inputStream.ReadLine();
        var containedPairCount = 0;
        while (!string.IsNullOrWhiteSpace(line))
        {
            var pair = line.Split(',');
            var elf1 = pair[0].Split('-');
            var elf2 = pair[1].Split('-');
            int.TryParse(elf1[0], out int elf1LB);
            int.TryParse(elf1[1], out int elf1UB);
            int.TryParse(elf2[0], out int elf2LB);
            int.TryParse(elf2[1], out int elf2UB);

            bool check1=false, check2 = false, check3 = false, check4 = false;
            if (elf1LB <= elf2LB && elf2LB <= elf1UB) check1 = true;
            if (elf1LB <= elf2UB && elf2UB <= elf1UB) check2 = true;
            if (elf2LB <= elf1LB && elf1LB <= elf2UB) check3 = true;
            if (elf2LB <= elf1UB && elf1UB <= elf2UB) check4 = true;

            if ((check1 && check2) || (check3 && check4)) containedPairCount++;
            line = inputStream.ReadLine();
        }
        Console.Write(containedPairCount);
    }


    public static void Part2()
    {
        var inputStream = new StreamReader("inputs/04.txt");
        var line = inputStream.ReadLine();
        var containedPairCount = 0;
        while (!string.IsNullOrWhiteSpace(line))
        {
            var pair = line.Split(',');
            var elf1 = pair[0].Split('-');
            var elf2 = pair[1].Split('-');
            int.TryParse(elf1[0], out int elf1LB);
            int.TryParse(elf1[1], out int elf1UB);
            int.TryParse(elf2[0], out int elf2LB);
            int.TryParse(elf2[1], out int elf2UB);

            bool check1 = false, check2 = false, check3 = false, check4 = false;
            if (elf1LB <= elf2LB && elf2LB <= elf1UB) check1 = true;
            if (elf1LB <= elf2UB && elf2UB <= elf1UB) check2 = true;
            if (elf2LB <= elf1LB && elf1LB <= elf2UB) check3 = true;
            if (elf2LB <= elf1UB && elf1UB <= elf2UB) check4 = true;

            if (check1 || check2 || check3 || check4) containedPairCount++;
            line = inputStream.ReadLine();
        }
        Console.Write(containedPairCount);
    }


}
