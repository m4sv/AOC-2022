using System.Collections;

public class Day10
{
    public static void Part1()
    {
        var instructions = File.ReadAllLines("inputs/10.txt");
        var cycles = new List<Cycle>();
        var currentCycle = 1;
        var xval = 1;
        var strength = 0;
        for (var i = 0; i < instructions.Length; i++)
        {
            if (string.IsNullOrEmpty(instructions[i])) break;
            var command = instructions[i].Split(' ');
            var inst = command[0];
            int value = 0;
            if (command.Length > 1) int.TryParse(command[1], out value);
            if (inst == "addx") currentCycle += 2;
            else currentCycle += 1;
            cycles.Add(new Cycle() {cycle = currentCycle, number=value});
        }
        cycles = cycles.OrderBy(x => x.cycle).ToList();
        var reportingCycles = new List<int> { 20, 60, 100, 140, 180, 220 };
        for(var i=1; i<250; i++)
        {
            var current = cycles.FirstOrDefault(x => x.cycle == i);
            if(current != null) xval += current.number;
            if (reportingCycles.Contains(i))
            {
                strength += i * xval;
            }
        }
        Console.WriteLine(strength);
    }

    public static void Part2()
    {
        var instructions = File.ReadAllLines("inputs/10.txt");
        var cycles = new List<Cycle>();
        var currentCycle = 1;
        var xval = 1;
        for (var i = 0; i < instructions.Length; i++)
        {
            if (string.IsNullOrEmpty(instructions[i])) break;
            var command = instructions[i].Split(' ');
            var inst = command[0];
            int value = 0;
            if (command.Length > 1) int.TryParse(command[1], out value);
            if (inst == "addx") currentCycle += 2;
            else currentCycle += 1;
            cycles.Add(new Cycle() { cycle = currentCycle, number = value });
        }
        cycles = cycles.OrderBy(x => x.cycle).ToList();

        var output = new char[240];
        var cursor = new int[3] {0,1,2};
        for (var i = 1; i <= 240; i++)
        {
            output[i - 1] = '.';
            if (i == 41 || i == 81 || i == 121 || i == 161 || i == 201) xval += 40;

            var current = cycles.FirstOrDefault(x => x.cycle == i);
            if (current != null)
            {
                xval += current.number;
                cursor[0] = xval-1;
                cursor[1] = xval;
                cursor[2] = xval+1;
            }
            if (cursor.Contains(i-1)) output[i - 1] = '#';
        }
        string line1 = new string(output.Take(40).ToArray()) + "\n";
        string line2 = new string(output.Skip(40).Take(40).ToArray()) + "\n";
        string line3 = new string(output.Skip(80).Take(40).ToArray()) + "\n";
        string line4 = new string(output.Skip(120).Take(40).ToArray()) + "\n";
        string line5 = new string(output.Skip(160).Take(40).ToArray()) + "\n";
        string line6 = new string(output.Skip(200).Take(40).ToArray()) + "\n";
        Console.WriteLine($"{line1}{line2}{line3}{line4}{line5}{line6}");
    }

    public class Cycle
    {
        public int cycle { get; set; }
        public int number { get; set; }
    }
}
