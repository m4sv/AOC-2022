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
    var p1Throw = line[0] - 64; // ASCII A = 65
    var p2Throw = line[2] - 87; // ASCII X = 88
    var finalScore = p2Throw;

    if      (p1Throw == p2Throw) finalScore += 3;
    else if ((p2Throw == 1 && p1Throw == 3) ||
             (p2Throw == 2 && p1Throw == 1) ||
             (p2Throw == 3 && p1Throw == 2))
    {
        finalScore += 6;
    }
    return finalScore;
}

int scoreLinePart2(string line)
{
    var p1Throw = line[0] - 64; // ASCII A = 65
    var p2Throw = line[2] - 88; // ASCII X = 88
    var finalScore = p2Throw * 3;

    switch (p2Throw)
    {
        case 0: //lose
            if      (p1Throw == 1)  finalScore += 3;
            else if (p1Throw == 2)  finalScore += 1;
            else if (p1Throw == 3)  finalScore += 2;
                break;
        case 1: //draw
            finalScore += p1Throw;
            break;
        case 2: //win
            if      (p1Throw == 1) finalScore += 2;
            else if (p1Throw == 2) finalScore += 3;
            else if (p1Throw == 3) finalScore += 1;
            break;
    }

    return finalScore;
}
