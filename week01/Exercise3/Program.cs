using System;

class Program
{
    static void Main(string[] args)
    {
        // Generate a random number between 1 and 100
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101); 
        Console.WriteLine("A magic number has been generated!");

        int guess = 0; 
        do
        {
            Console.Write("What is your guess? ");
            // Read user input and parse it to an integer
            string userInput = Console.ReadLine();
            bool isValid = int.TryParse(userInput, out guess);

            if (!isValid)
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            // Check if the guess is higher, lower, or correct
            if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        } while (guess != number); 
    }
}
