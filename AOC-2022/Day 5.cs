using System.Collections;

public class Day5
{
    public static void Part1()
    {
        var inputStream = new StreamReader("inputs/05.txt");
        var line = inputStream.ReadLine();
        var stackCount = (line.Length / 4) + 1;
        var reverseStacks = Enumerable.Range(0, stackCount).Select(x => new Stack()).ToList();

        while (!string.IsNullOrWhiteSpace(line))
        {
            if (line[1] != '1')
            {
                for (int i = 1, column = 0; i < line.Length; i += 4)
                {
                    if (line[i] != ' ') reverseStacks[column].Push(line[i]);
                    column++;
                }
            }
            line = inputStream.ReadLine();
        }
        var stacks = reverseStacks.Select(x => new Stack(x)).ToList();

        line = inputStream.ReadLine();

        while (!string.IsNullOrWhiteSpace(line))
        {
            var instructions = line.Split(' ');
            var numberToMove = int.Parse(instructions[1]);
            var startColumn = int.Parse(instructions[3])-1;
            var endColumn = int.Parse(instructions[5])-1;

            for (var i = 0; i < numberToMove; i++) 
            {
                var crate = stacks[startColumn].Pop();
                stacks[endColumn].Push(crate);
            }
            line = inputStream.ReadLine();
        }
        Console.WriteLine(String.Join(string.Empty, stacks.Select(x=> x.Peek()?.ToString()).ToArray()));
    }

    public static void Part2()
    {
        var inputStream = new StreamReader("inputs/05.txt");
        var line = inputStream.ReadLine();
        var stackCount = (line.Length / 4) + 1;
        var reverseStacks = Enumerable.Range(0, stackCount).Select(x => new Stack()).ToList();

        while (!string.IsNullOrWhiteSpace(line))
        {
            if (line[1] != '1')
            {
                for (int i = 1, column = 0; i < line.Length; i += 4)
                {
                    if (line[i] != ' ') reverseStacks[column].Push(line[i]);
                    column++;
                }
            }
            line = inputStream.ReadLine();
        }
        var stacks = reverseStacks.Select(x => new Stack(x)).ToList();

        line = inputStream.ReadLine();
        while (!string.IsNullOrWhiteSpace(line))
        {
            var instructions = line.Split(' ');
            var numberToMove = int.Parse(instructions[1]);
            var startColumn = int.Parse(instructions[3]) - 1;
            var endColumn = int.Parse(instructions[5]) - 1;

            var grabStack = new Stack();

            for (var i = 0; i < numberToMove; i++) grabStack.Push(stacks[startColumn].Pop());

            var grabCount = grabStack.Count;
            for (var i = 0; i < grabCount; i++) stacks[endColumn].Push(grabStack.Pop());

            line = inputStream.ReadLine();
        }
        Console.WriteLine(String.Join(string.Empty, stacks.Select(x => x.Peek()?.ToString()).ToArray()));
    }
}
