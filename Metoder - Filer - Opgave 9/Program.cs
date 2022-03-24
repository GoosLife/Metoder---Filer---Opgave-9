using System;
using System.IO;

namespace Metoder___Filer___Opgave_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.SetupConsole();

            DisplayMainMenu();
        }

        private static void AddFile()
        {
            Console.Clear();

            ConsoleHelper.Header("Name new file:");

            string filename = ConsoleHelper.ReadLine();

            File.Create(@".\" + filename);

            ConsoleHelper.WriteLine(filename + " created at " + Directory.GetCurrentDirectory());

            Console.ReadKey();
            Console.Clear();
            DisplayMainMenu();
        }

        private static void DeleteFile()
        {
            Console.Clear();

            string[] files = Directory.GetFiles(@".\");

            ConsoleHelper.Header("Choose a file to delete");

            int fileToDelete = ConsoleHelper.MultipleChoice(true, 1, files);

            if (fileToDelete != -1)
            {
                try
                {
                    File.Delete(files[fileToDelete]);
                    ConsoleHelper.WriteLine("File has been deleted");
                }
                catch (IOException ex)
                {
                    ConsoleHelper.WriteLine("File is in use by another process. Shut down that process and try again.");
                }
            }

            Console.ReadKey();
            Console.Clear();
            DisplayMainMenu();
        }

        private static void DisplayFiles()
        {
            Console.Clear();

            string[] files = Directory.GetFiles(@".\");

            ConsoleHelper.Header("Files in " + Directory.GetCurrentDirectory());

            for (int i = 0; i < files.Length; i++)
            {
                ConsoleHelper.WriteLine(files[i]);
            }

            Console.ReadKey();
            Console.Clear();
            DisplayMainMenu();
        }

        private static void AddFolder()
        {
            Console.Clear();

            ConsoleHelper.Header("Add folder");

            string folderName = ConsoleHelper.ReadLine();

            Directory.CreateDirectory(@".\" + folderName);

            ConsoleHelper.WriteLine("Folder " + folderName + " added to " + Directory.GetCurrentDirectory());

            Console.ReadKey();
            Console.Clear();
            DisplayMainMenu();
        }

        private static void SearchFolder()
        {
            Console.Clear();

            string[] files;

            ConsoleHelper.Header("Enter filetype to search for:");

            string searchTerm = ConsoleHelper.ReadLine();

            if (!searchTerm.Contains("."))
            {
                files = Directory.GetFiles(@".\", "*." + searchTerm);

            }
            else
            {
                files = Directory.GetFiles(@".\", "*" + searchTerm);
            }

            if (files.Length > 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    ConsoleHelper.WriteLine(files[i]);
                }
            }
            else
            {
                ConsoleHelper.WriteLine("No files of type " + searchTerm + " found.");
            }

            Console.ReadKey();
            Console.Clear();
            DisplayMainMenu();
        }

        private static void Exit()
        {
            Console.Clear();

            ConsoleHelper.Header("Bye, bye!");
        }

        private static void DisplayMainMenu()
        {
            ConsoleHelper.Header("H1 Queue Operations Menu");

            switch (MainMenuChoice())
            {
                case 0:
                    AddFile();
                    break;
                case 1:
                    DeleteFile();
                    break;
                case 2:
                    DisplayFiles();
                    break;
                case 3:
                    AddFolder();
                    break;
                case 4:
                    SearchFolder();
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("This menu choice does not exist");
            }

        }

        private static int MainMenuChoice()
        {
            string[] menuOptions =
{
                "1. Add file",
                "2. Delete file",
                "3. Display files",
                "4. Add folder",
                "5. Search for file in folder",
                "6. Exit",
            };

            int choice = ConsoleHelper.MultipleChoice(false, 1, menuOptions);

            return choice;
        }
    }
}
