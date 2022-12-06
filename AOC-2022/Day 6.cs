using System.Collections;

public class Day6
{
    public static void Part1()
    {
        var signal = File.ReadAllText("inputs/06.txt");
        var buff = new Queue<char>(4);
        for(int i = 0; i < signal.Length; i++)
        {
            if (buff.Count == 4)
            {
                if (!buff.GroupBy(x => x).Any(y => y.Count() > 1))
                {
                    var str = new string(buff.ToArray());
                    var index = signal.IndexOf(str) + 4;
                    Console.WriteLine(index);
                    return;
                }
                
            }
            buff.Enqueue(signal[i]);
            if (buff.Count > 4) buff.Dequeue();
        }
    }

    public static void Part2()
    {
        var signal = File.ReadAllText("inputs/06.txt");
        var buff = new Queue<char>(14);
        for (int i = 0; i < signal.Length; i++)
        {
            if (buff.Count == 14)
            {
                if (!buff.GroupBy(x => x).Any(y => y.Count() > 1))
                {
                    var str = new string(buff.ToArray());
                    var index = signal.IndexOf(str) + 14;
                    Console.WriteLine(index);
                    return;
                }
            }
            buff.Enqueue(signal[i]);
            if (buff.Count > 14) buff.Dequeue();
        }
    }
}
