using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\sharr\Videos\movies";
        DeleteFoldersLessThan100MB(path);
    }

    static void DeleteFoldersLessThan100MB(string path)
    {
        try
        {
            foreach (var directory in Directory.GetDirectories(path))
            {
                long size = GetDirectorySize(directory);
                if (size < 100 * 1024 * 1024)
                {
                    Directory.Delete(directory, true);
                }
                else
                {
                    DeleteFoldersLessThan100MB(directory);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static long GetDirectorySize(string path)
    {
        long size = 0;
        DirectoryInfo di = new DirectoryInfo(path);
        foreach (FileInfo fi in di.GetFiles())
        {
            size += fi.Length;
        }
        foreach (DirectoryInfo dir in di.GetDirectories())
        {
            size += GetDirectorySize(dir.FullName);
        }
        return size;
    }
}
