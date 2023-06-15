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
        

        ReadFromFile();

        Console.WriteLine("Done");

    }

    private static void ReadFromFile()
    {
        FileStream fs = new FileStream(@"hello.txt", FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        Console.WriteLine(sr.ReadToEnd());
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