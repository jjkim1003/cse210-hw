using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Create a list to store the numbers
        List<int> numbers = new List<int>();

        // Continuously read user input
        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            // Convert the input to an integer
            if (int.TryParse(input, out int number))
            {
                // Check if the user entered 0 to stop input
                if (number == 0)
                {
                    break;
                }

                // Add the number to the list
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        // Calculate the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Calculate the average
        double average = (numbers.Count > 0) ? (double)sum / numbers.Count : 0;

        // Find the largest number
        int largest = int.MinValue;
        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
        }

        // Find the smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        // Handle the case where there are no positive numbers
        string smallestPositiveOutput = (smallestPositive == int.MaxValue) ? "No positive numbers" : smallestPositive.ToString();

        // Display the results
        Console.WriteLine($"\nThe sum of the numbers is: {sum}");
        Console.WriteLine($"The average of the numbers is: {average:F5}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallestPositiveOutput}");

        // Sort the numbers in ascending order
        numbers.Sort();

        // Display the numbers in sorted order
        Console.WriteLine("\nYou entered the following numbers:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
