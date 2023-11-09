using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: CurseDelete.exe [target_directory]");
            Console.WriteLine("   [target_directory] - Specify the path to the directory you want to delete.");
            return;
        }

        string directoryPath = args[0];

        try
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            if (directory.Exists)
            {
                DeleteDirectory(directory);
                Console.WriteLine("Files and folders deleted successfully.");
            }
            else
            {
                Console.WriteLine("Directory not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void DeleteDirectory(DirectoryInfo directory)
    {
        foreach (FileInfo file in directory.GetFiles())
        {
            Console.WriteLine($"Deleting file: {file.FullName}");
            file.Delete();
        }

        foreach (DirectoryInfo subDirectory in directory.GetDirectories())
        {
            DeleteDirectory(subDirectory);
            Console.WriteLine($"Deleting directory: {subDirectory.FullName}");
        }

        Console.WriteLine($"Deleting directory: {directory.FullName}");
        directory.Delete();
    }
}
