using System;
using System.Diagnostics;

namespace ConsoleApp1
{

    internal class Program
    {

        static public class FileManager
        {
        
            private static DriveInfo[] GetAvailableDrives()
            {
                return DriveInfo.GetDrives();
            }

            public static void DisplayDirectoryContents(string path)
            {
                try
                {
                    var directories = Directory.GetDirectories(path);
                    var files = Directory.GetFiles(path);


                    foreach (var directory in directories)
                    {
                        Console.WriteLine($"  [DIR] {Path.GetFileName(directory)}");
                        
                    }

                    foreach (var file in files)
                    {
                        Console.WriteLine($"  [FILE] {Path.GetFileName(file)}");
                    }

                    while (true) {

                        int folderchoice = Menu.Show(1, directories.Length + files.Length);
                        
                       

                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            break;
                        }

                        if (folderchoice <= directories.Length)
                        {
                            var enteredDirectory = directories[folderchoice - 1];
                            path = Path.Combine(path, enteredDirectory);
                            Console.Clear();
                            Console.WriteLine($"Current Directory: {path}");
                            DisplayDirectoryContents(path);
                        }
                        else if (folderchoice > directories.Length)
                        {
                            var enteredDirectory = files[(folderchoice - 1)- directories.Length];
                            path = Path.Combine(path, enteredDirectory);
                            Process.Start(path);

                        
                        }

                       
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("  Access denied to some folders or files.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  An error occurred: {ex.Message}");
                }

            }

            public static void DrivesInfo()
            {
               while (true)
                {
                    Console.SetCursorPosition(0,0);
                    Console.WriteLine("File manager choose disk");
                    var drives = GetAvailableDrives();

                    for (int i = 1; i < drives.Length; i++)
                    {
                     
                        Console.WriteLine($"  {i }. {drives[i].Name} Total size {drives[i].TotalSize / (1024 * 1024 * 1024)} GB. Free space {drives[i].TotalFreeSpace / (1024 * 1024 * 1024)} GB" + $"");

                    }
                    Console.SetCursorPosition(0, 1);
                    int choice = Menu.Show(1, drives.Length - 1);

                    var selectDrive = drives[choice];
                    string currentPath = selectDrive.Name;


                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"Current Directory: {currentPath}");
                        DisplayDirectoryContents(currentPath);
                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            break;
                        }

                    }
                }
            }

        }

        static void Main(string[] args)
        {

                
                Console.Clear();
                
                FileManager.DrivesInfo();
                


        }
    }
}