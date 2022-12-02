var inputStream = new StreamReader("inputs/02.txt");

var finalScorePart1 = 0;
var finalScorePart2 = 0;
var line = inputStream.ReadLine();

while (!string.IsNullOrWhiteSpace(line))
{
    finalScorePart1 += scoreLinePart1(line);
    finalScorePart2 += scoreLinePart2(line);
    line = inputStream.ReadLine();
}

Console.WriteLine($"Part 1:{finalScorePart1}");
Console.WriteLine($"Part 2:{finalScorePart2}");


int scoreLinePart1(string line)
{
    switch (line)
    {
        case "A X": return 4;
        case "A Y": return 8;
        case "A Z": return 3;
        case "B X": return 1;
        case "B Y": return 5;
        case "B Z": return 9;
        case "C X": return 7;
        case "C Y": return 2;
        case "C Z": return 6;
    }
    return 0;
}

int scoreLinePart2(string line)
{
    switch (line)
    {
        case "A X": return 3;
        case "A Y": return 4;
        case "A Z": return 8;
        case "B X": return 1;
        case "B Y": return 5;
        case "B Z": return 9;
        case "C X": return 2;
        case "C Y": return 6;
        case "C Z": return 7;
    }
    return 0;
}
