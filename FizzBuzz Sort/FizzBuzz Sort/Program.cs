using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz_Sort
{
    class Program
    {
        public static void exchange(int[] data, int m, int n)
        {
            int temporary;
            // Appreciation to anh.cs.luc.edu/
            temporary = data[m];
            data[m] = data[n];
            data[n] = temporary;
        }

        static void Main(string[] args)
        {
            string listName = "Stopgag";
            Console.WriteLine("Loading file...");
            int[] list = readFromFile();
            Console.WriteLine("File loaded.");
            Console.WriteLine("Welcome to FizzBuzz!  Choose a version:");
            Console.WriteLine();
            Console.WriteLine("1. FizzBuzz");
            Console.WriteLine("2. Boom");
            Console.WriteLine();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List(list);
                    FizzBuzzList(listName, list);
                    break;
                case "2":
                    List(list);
                    BoomList(listName, list);
                    break;
                default:
                    Console.WriteLine("Not a valid choice.");
                    break;
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        static int[] readFromFile() // thank you Cameron for writing this out before!
        {
            {
                string fileContents = File.ReadAllText("C:\\dev\\data\\unsorted-numbers.txt");
                string[] numbersAsStrings = fileContents.Split(',');
                int[] numbers = new int[numbersAsStrings.Length];
                for (int i = 0; i < numbersAsStrings.Length; i++)
                {
                    numbers[i] = int.Parse(numbersAsStrings[i]);
                }
                return numbers;
            }
        }

        static void List(int[] list)
        {
            int x, y;
            int List = list.Length;
            for (y = 1; y < List; y++)
            {
                for (x = y; x > 0 && list[x] < list[x - 1]; x--)
                {
                    exchange(list, x, x - 1);
                }
            }
        }


        static void FizzBuzzList(string listName, int[] list)
        {
            listName = "FizzBuzz";
            Console.WriteLine("-- " + listName + " --");
            for (int i = 0; i < list.Length; i++)
            {
                if ((i + 1) % 5 == 0 || (i + 1) % 3 == 0)
                {
                    if ((i + 1) % 3 == 0)
                    {
                        Console.Write("Fizz, ");
                    }
                    if ((i + 1) % 5 == 0)
                    {
                        Console.Write("Buzz, ");
                    }
                    if ((i + 1) % 5 == 0 && (i + 1) % 3 == 0)
                    {
                        Console.Write("FizzBuzz, ");
                    }
                }
                else
                {
                    Console.Write(list[i] + ", ");
                }
            }
            Console.WriteLine();
        }

        static void BoomList(string listName, int[] list)
        {
            listName = "Boom!";
            Console.WriteLine("-- " + listName + " --");
            for (int i = 0; i < list.Length; i++)
            {
                if ((i+1)% 7 == 0)
                {
                    Console.Write("Boom!, ");
                }
                else
                {
                    Console.Write(list[i] + ", ");
                }
            }
            Console.WriteLine();
        }
    }
}