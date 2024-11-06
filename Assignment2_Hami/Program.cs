using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Assignment2_Hami
{
    class Program
    {
        private static DLList wordList = new DLList();
        private static string loadedFile = "No";

        static void Main(string[] args)
        {
            MainMenu();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------- Main Menu --------");
                Console.WriteLine("0 - Load File");
                Console.WriteLine("1 - Insert Word");
                Console.WriteLine("2 - Delete Word");
                Console.WriteLine("3 - Find Word");
                Console.WriteLine("4 - Print Words");
                Console.WriteLine("5 - Test");
                Console.WriteLine("6 - Exit");
                Console.WriteLine("---------------------------");
                Console.Write("Enter your choice (0-6): ");


                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 0:
                            LoadOp();
                            break;
                        case 1:
                            InsertWord();
                            break;
                        case 2:
                            DeleteWord();
                            break;
                        case 3:
                            FindWord();
                            break;
                        case 4:
                            PrintWords();
                            break;
                            case 5:
                            TestOp();
                                break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 5.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        static void TestOp()
        {
            LoadOp();
            InsertWord();
            DeleteWord();
            FindWord();
            PrintWords();
            TestOp();
        }

        static void LoadOp()
        {
            Console.Clear();
            int userInputLoad = 0;
            int passed = 0;
            int failed = 0;
            string folderPathWord = @"Word Files";           
            int Curser = 0;
            List<string> list = new List<string>();
            string[] filesWordFiles = Directory.GetFiles(folderPathWord, "*.txt");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---File Selector---");
                Console.WriteLine();
                Curser = 0;
                foreach (string file in filesWordFiles)
                {
                    Console.WriteLine(Curser + "- " + file);
                    list.Insert(Curser, file);
                    Curser++;
                }
                Console.WriteLine(Curser + "- Go back to go and do not collect 200 from the bank");
                Console.WriteLine();
                Console.WriteLine("Enter 0 - {0} from the list above, you can count", Curser);
                if (int.TryParse(Console.ReadLine(), out userInputLoad))
                {
                    if (userInputLoad >= 0 && userInputLoad <= Curser)
                    {
                        if (userInputLoad == Curser)
                        {
                            break;
                        }
                        string fileDs = list.ToArray()[userInputLoad];
                        Console.WriteLine(fileDs);

                        string[] lines = File.ReadAllLines(fileDs);
                        foreach(var l in lines)
                        {
                            wordList.Insert(l);
                        }
                        Stopwatch stopwatch = Stopwatch.StartNew();

                        Curser = 0;
                        foreach (string line in lines)
                        {
                            Curser++;
                            if (line.All(char.IsLetterOrDigit))
                            {
                                Console.WriteLine(line);
                                passed++;
                            }
                            else
                            {
                                failed++;
                            }
                        }
                        Console.WriteLine("\n");
                        Console.WriteLine("File Number Selected: " + userInputLoad);
                        Console.WriteLine("Total Number of Successful Addtion: " + passed);
                        Console.WriteLine("Total Number of Failed Addtion: " + failed);
                        Console.WriteLine("Total: " + Curser);
                        Console.WriteLine("Time Taken: " + stopwatch.Elapsed.TotalSeconds + " seconds");
                        Console.WriteLine("\n");
                        Console.WriteLine("Press any key to go to Main and pay for Arohaina food...");
                        Console.ReadKey();
                    }
                }
            }
        }

        static void InsertWord()
        {
            Console.Write("Enter a word to insert: ");
            string word = Console.ReadLine();
            wordList.Insert(word);
            Console.WriteLine($"Inserted: {word}");
        }

        static void DeleteWord()
        {
            Console.Write("Enter a word to delete: ");
            string word = Console.ReadLine();
            if (wordList.Delete(word))
            {
                Console.WriteLine($"Deleted: {word}");
            }
            else
            {
                Console.WriteLine($"Word '{word}' not found.");
            }
        }

        static void FindWord()
        {
            Console.Write("Enter a word to find: ");
            string word = Console.ReadLine();
            var node = wordList.Find(word);
            if (node != null)
            {
                Console.WriteLine($"Found: {node.ToPrint()}");
            }
            else
            {
                Console.WriteLine($"Word '{word}' not found.");
            }
        }

        static void PrintWords()
        {
            Console.WriteLine(wordList.ToString());
        }
    }
}

