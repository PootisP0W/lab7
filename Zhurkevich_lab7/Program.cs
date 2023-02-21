using System.Diagnostics;
using System.Text.RegularExpressions;
using Zhurkevich_lab7;

Explorer.PrintDrives();
int current = 0;
DirectoryInfo currentDirectoryInfo = null;
ArrowsManager arrowsManager = new ArrowsManager(3, Explorer.DrivesInfo.Length+2);

while (true)
{
    try
    {
        if (currentDirectoryInfo == null)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if (current == Explorer.DrivesInfo.Length - 1)
                    {
                        current = 0;
                    }
                    else
                    {
                        current++;
                    }
                    arrowsManager.Down();
                    break;
                case ConsoleKey.UpArrow:
                    if (current == 0)
                    {
                        current = Explorer.DrivesInfo.Length - 1;
                    }
                    else
                    {
                        current--;
                    }
                    arrowsManager.Up();
                    break;
                case ConsoleKey.Enter:
                    currentDirectoryInfo = Explorer.PickDrive(Explorer.DrivesInfo[current]);
                    arrowsManager = new ArrowsManager(3, currentDirectoryInfo.GetDirectories().Length + currentDirectoryInfo.GetFiles().Length + 2);
                    current = 0;
                    Console.SetCursorPosition(0, 0);
                    break;
            }
        }
        else
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if (current == currentDirectoryInfo.GetDirectories().Length + currentDirectoryInfo.GetFiles().Length - 1)
                    {
                        current = 0;
                    }
                    else
                    {
                        current++;
                    }
                    arrowsManager.Down();
                    break;
                case ConsoleKey.UpArrow:
                    if (current == 0)
                    {
                        current = currentDirectoryInfo.GetDirectories().Length + currentDirectoryInfo.GetFiles().Length - 1;
                    }
                    else
                    {
                        current--;
                    }
                    arrowsManager.Up();
                    break;
                case ConsoleKey.Enter:
                    if (currentDirectoryInfo.GetDirectories().Length == 0 && currentDirectoryInfo.GetFiles().Length == 0)
                    {
                        break;
                    }
                    if (current < currentDirectoryInfo.GetDirectories().Length)
                    {
                        currentDirectoryInfo = Explorer.PickDirectory(currentDirectoryInfo.GetDirectories()[current]);
                        arrowsManager = new ArrowsManager(3, currentDirectoryInfo.GetDirectories().Length + currentDirectoryInfo.GetFiles().Length + 2);
                        current = 0;
                        Console.SetCursorPosition(0, 0);
                    }
                    else
                    {
                        string name = currentDirectoryInfo.GetFiles()[current - currentDirectoryInfo.GetDirectories().Length].FullName;
                        Process.Start(new ProcessStartInfo(name) { UseShellExecute = true });
                    }
                    break;
                case ConsoleKey.Escape:
                    if (currentDirectoryInfo.Parent == null)
                    {
                        Explorer.PrintDrives();
                        currentDirectoryInfo = null;
                        arrowsManager = new ArrowsManager(3, Explorer.DrivesInfo.Length + 2);
                    }
                    else
                    {
                        currentDirectoryInfo =  Explorer.Escape(currentDirectoryInfo);
                        arrowsManager = new ArrowsManager(3, currentDirectoryInfo.GetDirectories().Length + currentDirectoryInfo.GetFiles().Length + 2);
                        Console.SetCursorPosition(0, 0);
                    }
                    current = 0;
                    break;
            }
        }
    }
    catch (Exception ex)
    {

    }
}