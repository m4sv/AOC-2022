using System.Collections;

public class Day8
{
    public static void Part1()
    {
        var grid = File.ReadAllLines("inputs/08.txt");
        var visibleTrees = 0;

        visibleTrees += grid[0].Length * 2;
        visibleTrees += (grid.Length - 2) * 2;

        for(int y = 1; y < grid.Length-1; y++)
        {
            for(int x = 1; x < grid[y].Length-1; x++)
            {
                var line = grid[y];
                var column = new string(grid.Select(row => row[x]).ToArray());
                var tree = grid[y][x];

                bool visibleL = true, visibleR = true, visibleU = true, visibleD = true;

                for (int i = x - 1; i >= 0; i--)
                {
                    if (tree > line[i]) visibleL = true;
                    else { visibleL = false; break; }
                }
                if (visibleL) { visibleTrees++; continue; }
                for(int j = x + 1; j < line.Length; j++)
                {
                    if (tree > line[j]) visibleR = true;
                    else { visibleR = false; break; }
                }
                if (visibleR) { visibleTrees++; continue; }
                for (int i = y - 1; i >= 0; i--)
                {
                    if (tree > column[i]) visibleU = true;
                    else { visibleU = false; break; }
                }
                if (visibleU) { visibleTrees++; continue; }
                for (int j = y + 1; j < column.Length; j++)
                {
                    if (tree > column[j]) visibleD = true;
                    else { visibleD = false; break; }
                }
                if (visibleD) { visibleTrees++; continue; }
            }
        }
        Console.WriteLine(visibleTrees);
    }


    public static void Part2()
    {
        var grid = File.ReadAllLines("inputs/08.txt");
        var visibleTrees = 0;

        var scenicScores = new List<int>();

        visibleTrees += grid[0].Length * 2;
        visibleTrees += (grid.Length - 2) * 2;

        for (int y = 1; y < grid.Length - 1; y++)
        {
            for (int x = 1; x < grid[y].Length - 1; x++)
            {
                var line = grid[y];
                var column = new string(grid.Select(row => row[x]).ToArray());
                var tree = grid[y][x];

                int viewL = 0, viewR = 0, viewU = 0, viewD = 0;
                for (int i = x - 1; i >= 0; i--)
                {
                    if (tree > line[i]) viewL++;
                    else { viewL++; break; }
                }
                for (int j = x + 1; j < line.Length; j++)
                {
                    if (tree > line[j]) viewR++;
                    else { viewR++; break; }
                }
                for (int i = y - 1; i >= 0; i--)
                {
                    if (tree > column[i]) viewU++;
                    else { viewU++; break; }
                }
                for (int j = y + 1; j < column.Length; j++)
                {
                    if (tree > column[j]) viewD++;
                    else { viewD++; break; }
                }
                scenicScores.Add(viewU * viewL * viewR * viewD);
            }
        }
        
        Console.WriteLine(scenicScores.Max());
    }
}
