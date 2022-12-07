using System.Collections;

public class Day7
{
    static Dictionary<string, Dir> directory = new Dictionary<string, Dir>();
    public static void Part1()
    {
        var inputStream = new StreamReader("inputs/07.txt");
        string currentDirectory = null, parentDirectory = "/";
        var line = inputStream.ReadLine();
        while (!string.IsNullOrWhiteSpace(line))
        {
            if (line.StartsWith("$ cd"))
            {
                var parseValue = line.Split(' ')[2];
                if (parseValue == "..")
                {
                    currentDirectory = directory[currentDirectory].ParentName;
                }
                else
                {
                    currentDirectory = parseValue;
                    if (!directory.ContainsKey(currentDirectory))
                    {
                        directory.Add(currentDirectory, new Dir(parentDirectory));
                    }
                    parentDirectory = currentDirectory;
                }
            }
            else if (line.StartsWith("$ ls"))
            {
                line = inputStream.ReadLine();
                continue;
            }
            else if (line.StartsWith("dir"))
            {
                var items = line.Split(' ');
                if (!directory.ContainsKey(items[1]))
                {
                    directory.Add(items[1], new Dir(currentDirectory));
                }
            }
            else
            {
                var items = line.Split(' ');
                int.TryParse(items[0], out int itemSize);
                var name = items[1];
                directory[currentDirectory].Files.Add(new DirFile { Name = name, Size = itemSize });
            }
            line = inputStream.ReadLine();
        }

        foreach (var item in directory)
        {
            if (item.Value.ParentName != null)
            {
                directory[item.Value.ParentName].Children.Add(item.Value);
            }
            item.Value.populateFileSizes();
        }

        var result = directory.Select(x => x.Value.GetDirectorySize()).Where(x => x <= 100000).Sum();

        Console.WriteLine(result);
    }

    public static void Part2()
    {
        var inputStream = new StreamReader("inputs/07.txt");
        var line = inputStream.ReadLine();
        while (!string.IsNullOrWhiteSpace(line))
        {
            line = inputStream.ReadLine();
        }
    }

    public class Dir
    {
        public Dir(string parentName)
        {
            ParentName = parentName;
            Files = new List<DirFile>();
            Children = new List<Dir>();
        }
        public void populateFileSizes()
        {
            Size = Files.Sum(x => x.Size);
        }
        public int GetDirectorySize()
        {
            return Children.Sum(x => x.Size) + Size;
        }
        public int Size { get; set; }
        public List<DirFile> Files { get; set; }
        public List<Dir> Children { get; set; }
        public string ParentName { get; set; }
    }

    public class DirFile
    {
        public string Name { get; set; }
        public int Size { get; set; }
    }

}
