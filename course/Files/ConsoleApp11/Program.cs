using System.IO;
using System.Text;

string path = @"C:\Otus";
var dir = new DirectoryInfo(path);
dir.Create();
dir.CreateSubdirectory("TestDir1");
dir.CreateSubdirectory("TestDir2");
try
{
    for (int i = 1; i < 10; i++)
    {
        var create1 = File.Create($@"{path}\TestDir1\File{i}.txt");
        var create2 = File.Create($@"{path}\TestDir2\File{i}.txt");
        create1.Close(); create2.Close();
    }
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Программе отказан доступ к $@\"{path}\\TestDir2\\");
}
try
{
    for (int i = 1; i < 10; i++)
    {
        File.AppendAllText($@"{path}\TestDir1\File{i}.txt", $"File{i}: {DateTime.Now}", Encoding.UTF8);
        File.AppendAllText($@"{path}\TestDir2\File{i}.txt", $"File{i}: {DateTime.Now}", Encoding.UTF8);
    }
}
catch(IOException)
{
    Console.WriteLine("Программе отказан доступ к одному или нескольки файлам");
}

for (int i = 1; i < 10; i++)
{
    using (FileStream stream = File.OpenRead($@"{path}\TestDir1\File{i}.txt"))
    {
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);
        Console.WriteLine("TestDir1 => " + Encoding.UTF8.GetString(buffer));
    }
    using (FileStream stream = File.OpenRead($@"{path}\TestDir2\File{i}.txt"))
    {
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);
        Console.WriteLine("TestDir2 => " + Encoding.UTF8.GetString(buffer));
    }
}
