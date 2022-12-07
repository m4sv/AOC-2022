using System.Collections;

public class Day7
{
    static Dictionary<string, Dir> directory = new Dictionary<string, Dir>();
    public static void Part1()
    {
        var inputStream = new StreamReader("inputs/07.txt");
        string currentDir = "/";

        var line = inputStream.ReadLine();
        while (!string.IsNullOrWhiteSpace(line))
        {
            //var currentFolder = "root";
            if (currentDir != "root/")
            {
                //var elements = currentDir.Split('/');
                //currentFolder = elements.LastOrDefault() ?? "root";
            }
            if (line.StartsWith("$ cd"))
            {
                var parseValue = line.Split(' ')[2];
                if (parseValue == ".." && currentDir != "root/")
                {
                    currentDir = currentDir.Replace($"/{currentDir.Split("/").LastOrDefault()}", "");
                }
                else if (parseValue == "/")
                {
                    currentDir = "root/";
                }
                else
                {
                    if (currentDir != "root/") currentDir += $"/{parseValue}";
                    else currentDir += parseValue;
                }
            }
            else if (line.StartsWith("$ ls"))
            {
                if(!directory.ContainsKey(currentDir)) directory.Add(currentDir, new Dir(currentDir));
                line = inputStream.ReadLine();
                continue;
            }
            else if (line.StartsWith("dir"))
            {
                var items = line.Split(' ');
                if (!directory.ContainsKey(items[1]))
                {
                    if (currentDir == "root/") directory.Add($"{currentDir}{items[1]}", new Dir(currentDir));
                    else directory.Add($"{currentDir}/{items[1]}", new Dir(currentDir));
                }
            }
            else
            {
                var items = line.Split(' ');
                int.TryParse(items[0], out int itemSize);
                var name = items[1];
                directory[currentDir].Files.Add(new DirFile { Name = name, Size = itemSize });
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

        var sizes = directory.Select(x => new KeyValuePair<string,int>(x.Key,x.Value.GetDirectorySize())).ToList();
        var size2 = directory.Select(x => new KeyValuePair<string, int>(x.Key, x.Value.Children.Count())).OrderBy(x=> x.Value).ToList();
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
