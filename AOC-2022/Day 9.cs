using System.Collections;

public class Day9
{
    public static void Part1()
    {
        var inputStream = new StreamReader("inputs/09.txt");
        var rope = new Rope();
        var line = inputStream.ReadLine();
        while (!string.IsNullOrWhiteSpace(line))
        {
            var parse = line.Split(' ');
            var direction = parse[0];
            var distance = int.Parse(parse[1]);
            rope.Move(direction, distance);
            line = inputStream.ReadLine();
        }
        var uniqueTailLocations = rope.TailLocations.GroupBy(p => new { p.x, p.y }).ToList();
        Console.WriteLine(uniqueTailLocations.Count);
    }

    public static void Part2()
    {
        var inputStream = new StreamReader("inputs/09.txt");
        var rope = new Rope();
        var line = inputStream.ReadLine();
        while (!string.IsNullOrWhiteSpace(line))
        {
            var parse = line.Split(' ');
            var direction = parse[0];
            var distance = int.Parse(parse[1]);
            rope.Move(direction, distance, false);
            line = inputStream.ReadLine();
        }

        var uniqueTailLocations = rope.TailLocations.GroupBy(p => new { p.x, p.y }).ToList();
        Console.WriteLine(uniqueTailLocations.Count);
    }

    public class Rope
    { 
        public Rope() 
        {
            Head = new Point();
            Tail = new Point();
            LastHead = new Point();
            CutTail = new List<Point>();
            for (var i = 0; i < 8; i++) CutTail.Add(new Point() { x = 0, y = 0 });
            TailLocations = new HashSet<Point>();
        }
        public Point Head { get; set; }
        public Point Tail { get; set; }

        public List<Point> CutTail { get; set; }

        Point LastHead { get; set; }
        public void Move(string direction, int distance, bool part1 = true)
        {
            int xDir = 0;
            int yDir = 0;
            switch (direction)
            {
                case "L": xDir = -1; break;
                case "R": xDir = 1; break;
                case "U": yDir = 1; break;
                case "D": yDir =  -1; break;
            }
            for (var i = 0; i < distance; i++)
            {
                LastHead = new Point(Head);
                Head.x += xDir;
                Head.y += yDir;
                if (part1)
                {
                    ResolveTail();
                    TailLocations.Add(new Point(Tail));
                }
                else
                {
                    ResolveCutTail();
                    TailLocations.Add(new Point(CutTail.Last()));
                }
            }
        }
        public void ResolveTail()
        {
            var xDist = Head.x - Tail.x;
            var yDist = Head.y - Tail.y;
            var distance = Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));
            if (distance >=2)
            {
                if (xDist != 0 && yDist != 0)
                {
                    Tail.x = LastHead.x;
                    Tail.y = LastHead.y;
                }
                else if (xDist != 0) Tail.x += Math.Sign(xDist);
                else if (yDist != 0) Tail.y += Math.Sign(yDist);
            }

        }

        public void ResolveCutTail()
        {
            ResolveTail();
            var previousKnot = new Point(Tail);
            for (int i = 0; i < CutTail.Count; i++)
            {
                var xDist = previousKnot.x - CutTail[i].x;
                var yDist = previousKnot.y - CutTail[i].y;
                var distance = Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));
                if (!previousKnot.isAdjacent(CutTail[i]))
                {
                    if (xDist != 0) CutTail[i].x += Math.Sign(xDist);
                    if (yDist != 0) CutTail[i].y += Math.Sign(yDist);
                }
                previousKnot = new Point(CutTail[i]);
            }
        }

        public HashSet<Point> TailLocations { get; set; }
    }

    public class Point
    {
        public Point() { }
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
        }
        public bool isAdjacent(Point p)
        {
            return ((p.x == x && p.y == y) ||
                    (p.x == x - 1 && p.y == y) ||
                    (p.x == x + 1 && p.y == y) ||
                    (p.x == x && p.y == y + 1) ||
                    (p.x == x && p.y == y - 1) ||
                    (p.x == x + 1 && p.y == y + 1) ||
                    (p.x == x - 1 && p.y == y - 1) ||
                    (p.x == x + 1 && p.y == y - 1) ||
                    (p.x == x - 1 && p.y == y + 1));
        }
        public int x { get; set; }
        public int y { get; set; }
    }

    public static void DrawRope(Rope rope)
    {
        var output = new char[50, 50];
        for (int i = 0; i < 50; i++) { for (int j = 0; j < 50; j++) { output[i, j] = '.'; } }
        int x = 25, y = 25;
        output[y, x] = 's';
        for (var i = 0; i < rope.CutTail.Count; i++)
        {
            var cut = rope.CutTail[i];
            output[cut.y + y, cut.x + x] = char.Parse($"{i + 2}");
        }
        output[rope.Head.y + y, rope.Head.x + x] = 'H';
        output[rope.Tail.y + y, rope.Tail.x + x] = '1';
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                Console.Write(output[i, j]);
            }
            Console.Write('\n');
        }
        Console.WriteLine("\n==============================================================\n");
    }
}
