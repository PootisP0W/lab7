using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhurkevich_lab7
{
    internal static class Explorer
    {
        public static DriveInfo[] DrivesInfo { get; private set; } = null;

        public static void PrintDrives()
        {
            DrivesInfo = DriveInfo.GetDrives().Where(d=>d.DriveType == DriveType.Fixed || d.DriveType == DriveType.Removable).ToArray();
            Console.Clear();
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Этот компьютер");
            for(int i = 0; i < 110;i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(0, 3);
            foreach (DriveInfo element in DrivesInfo)
            {
                Console.WriteLine($"  {element.Name} {element.TotalFreeSpace/1024/1024/1024} ГБ свободно из {element.TotalSize/1024/1024/1024} ГБ");
            }
            Console.SetCursorPosition(0,3);
            Console.Write("->");
        }

        public static DirectoryInfo PickDrive(DriveInfo driveInfo)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(driveInfo.Name);
            PrintDirectoryInfo(directoryInfo);
            return directoryInfo;
        }

        public static DirectoryInfo PickDirectory(DirectoryInfo directory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory.FullName);
            PrintDirectoryInfo(directoryInfo);
            return directoryInfo;
        }

        public static DirectoryInfo Escape(DirectoryInfo currentDirectoryInfo )
        {
            DirectoryInfo directoryInfo = currentDirectoryInfo.Parent;
            PrintDirectoryInfo(directoryInfo);
            return directoryInfo;
        }

        public static void PrintDirectoryInfo(DirectoryInfo directoryInfo)
        {
            Console.Clear();
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Папка {directoryInfo.Name}");
            for (int i = 0; i < 110; i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(20, 2);
            Console.Write("Название");
            Console.SetCursorPosition(65, 2);
            Console.Write("Дата создания");
            Console.SetCursorPosition(90, 2);
            Console.Write("Тип");
            Console.SetCursorPosition(0, 3);
            foreach (DirectoryInfo element in directoryInfo.GetDirectories())
            {
                Console.Write($"  {element.Name}");
                Console.SetCursorPosition(62, Console.CursorTop);
                Console.Write(element.CreationTime);
                Console.SetCursorPosition(89, Console.CursorTop);
                Console.Write(element.Extension);
                Console.WriteLine();
            }
            foreach (FileInfo element in directoryInfo.GetFiles())
            {
                Console.Write($"  {element.Name}");
                Console.SetCursorPosition(62, Console.CursorTop);
                Console.Write(element.CreationTime);
                Console.SetCursorPosition(89, Console.CursorTop);
                Console.Write(element.Extension);
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 3);
            Console.Write("->");
        }
    }
}
