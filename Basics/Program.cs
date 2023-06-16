internal class Program
{
    private static void Main(string[] args)
    {

        DirectoryInfo directory = new DirectoryInfo(@"New Folder");
        if (!directory.Exists)
        {
            directory.Create();
            Console.WriteLine("Directory was created");
        }

        Console.WriteLine(directory.CreationTime);
        Console.WriteLine(directory.LastAccessTime);


        FileInfo newFile = new FileInfo(@"hello.txt");
        if (!newFile.Exists)
        {
            newFile.Create();
            AppendTextToFile();
        }

        PathMethods(newFile);

        //        ReadFromFile();

        Console.WriteLine($"File Name = {newFile.Name}");
        Console.WriteLine("Done");

    }

    private static void PathMethods(FileInfo newFile)
    {
        Console.WriteLine(Path.GetFullPath(newFile.FullName));
        Console.WriteLine(Path.GetExtension(newFile.FullName));


        Console.WriteLine(Path.GetDirectoryName(newFile.FullName));
    }

    private static void ReadFromFile()
    {
        FileStream fs = new FileStream(@"hello.txt", FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        Console.WriteLine(sr.ReadToEnd());

        sr.Close();
        fs.Close();
    }

    private static void AppendTextToFile()
    {
        FileStream fs = new FileStream(@"hello.txt", FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        sw.AutoFlush = true;

        sw.WriteLine("Hello First Line");
        sw.Close();
        fs.Close();
    }
}