using System;
 

namespace ConsoleApp1
{
    internal class Program
    {
        private static DriveInfo[] GetAvailableDrives()
        {
            return DriveInfo.GetDrives();
        }

        private static void DisplayDriveInfo(DriveInfo drive)
        {
            Console.WriteLine($"Drive: {drive.Name}");
            Console.WriteLine($"Total Space: {drive.TotalSize / (1024 * 1024 * 1024)} GB");
            Console.WriteLine($"Used Space: {drive.TotalSize - drive.AvailableFreeSpace / (1024 * 1024 * 1024)} GB");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Menu menu = new Menu();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("File manager choose disk");
                var drives = GetAvailableDrives();
                for(int i =0; i < drives.Length; i++)
                {
                    Console.WriteLine($"  {i + 1}. {drives[i].Name}");
                    
                }
                Menu.Show(1, drives.Length);
            }

        }
    }
}