using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() 
        : base("Listing Activity", "This activity helps you reflect on the good things in your life by listing as many things as you can in a certain area.") 
    { }

    public void Run()
    {
        DisplayStartingMessage();

        // Pick a random prompt
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("\nYou will have a few seconds to think before listing items...");

        // Use spinning animation instead of countdown
        ShowSpinner(5);

        Console.WriteLine("\nStart listing items. Press Enter after each one.");
        List<string> items = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");
        DisplayEndingMessage();
    }

    // Overriding the default countdown with a spinner animation
    public new void ShowSpinner(int seconds)
    {
        char[] spinner = new char[] { '|', '/', '-', '\\' };
        int delay = 200; // Start fast
        int slowdownStep = 50; // Gradually slow down

        for (int i = 0; i < seconds * 4; i++) // 4 steps per second
        {
            Console.Write($"\r{spinner[i % 4]}"); // Rotate through spinner symbols
            Thread.Sleep(delay);
            delay += slowdownStep; // Gradually slow down
        }
        Console.Write("\r "); // Clear the spinner at the end
    }
}
