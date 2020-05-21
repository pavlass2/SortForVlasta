using System;
using System.Collections.Generic;

namespace SortForVlasta
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get numbers from user
            Console.WriteLine("Numbers must be integers, separeted by semicolon \";\", not lower than " + int.MinValue + " and not higher than " + int.MaxValue);
            string input = Console.ReadLine();

            // Split input into separeted strings
            string[] textNumbers = input.Split(";");

            // Validate strings and if succesful parse them
            List<int> numbers = new List<int>();
            foreach (string s in textNumbers)
            {
                try
                {
                    numbers.Add(int.Parse(s.Trim()));
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error! " + s + " is not an integer. Program shutting down.");
                    return;
                }
                catch(OverflowException ex)
                {
                    Console.WriteLine("Error! " + s + " is too high. Program shutting down.");
                    return;
                }
            }

            // Sort numbers
            List<int> sortedNumbers = new List<int>();
            while (numbers.Count > 0)
            {
                int? currentMaximum = null;
                foreach (int number in numbers)
                {
                    if (currentMaximum == null || number > currentMaximum)
                    {
                        currentMaximum = number;
                    }
                }
                numbers.Remove(currentMaximum.GetValueOrDefault());
                sortedNumbers.Add(currentMaximum.GetValueOrDefault());
            }

            // Show result
            Console.WriteLine("Sorted numbers:");
            foreach (int number in sortedNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
