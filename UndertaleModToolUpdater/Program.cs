using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace UndertaleModToolUpdater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PizzaTowerModTool updater";

            Process[] instances = Process.GetProcessesByName("PizzaTowerModTool");
            if (instances.Length > 0)
            {
                Console.WriteLine("Waiting for PizzaTowerModTool to close...");
                foreach (var instance in instances)
                    instance.WaitForExit();
            }

            string basePath = Path.Join(Path.GetTempPath(), "PizzaTowerModTool") + Path.DirectorySeparatorChar;
            string appPath = null;

            if (!File.Exists(basePath + "Update.zip"))
            {
                Console.WriteLine("Update.zip is missing! This program is not meant to be run by itself; please update through PizzaTowerModTool.");
                Console.WriteLine("Press any key to exit...");
                Console.Read();
                Environment.Exit(1);
            }

            if (Directory.Exists(basePath + "Update"))
            {
                Console.WriteLine("Removing Update folder...");
                Directory.Delete(basePath + "Update", true);
            }

            if (!File.Exists("actualAppFolder"))
            {
                Console.WriteLine("\"actualAppFolder\" file is missing!");
                Console.WriteLine("Press any key to exit...");
                Console.Read();
                Environment.Exit(1);
            }

            appPath = File.ReadAllText("actualAppFolder");
            File.Delete("actualAppFolder");

            Console.WriteLine("Extracting Update.zip...");
            ZipFile.ExtractToDirectory(basePath + "Update.zip", basePath + "Update", true);
            Console.WriteLine("Deleting Update.zip...");
            File.Delete(basePath + "Update.zip");
            Console.WriteLine("Replacing files with update...");
            MoveDirectory(basePath + "Update", appPath);
            Console.WriteLine("Finished updating, launching PizzaTowerModTool...");

            Process.Start(new ProcessStartInfo(Path.Join(appPath, "PizzaTowerModTool.exe"))
            {
                WorkingDirectory = appPath,
                Arguments = "deleteTempFolder"
            });
            Environment.Exit(0);
        }

        static void MoveDirectory(string source, string target)
        {
            var files = Directory.EnumerateFiles(source, "*", SearchOption.AllDirectories).GroupBy(s => Path.GetDirectoryName(s));
            foreach (var folder in files)
            {
                var targetFolder = folder.Key.Replace(source, target);
                Directory.CreateDirectory(targetFolder);
                foreach (var file in folder)
                {
                    var targetFile = Path.Join(targetFolder, Path.GetFileName(file));
                    if (File.Exists(targetFile)) File.Delete(targetFile);
                    File.Move(file, targetFile);
                }
            }
            Directory.Delete(source, true);
        }
    }
}
