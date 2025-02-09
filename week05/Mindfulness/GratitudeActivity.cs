using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "What are three things that made you smile today?",
        "Who are the people in your life you are most grateful for?",
        "What experiences have brought you joy recently?",
        "What is a personal strength or talent you are thankful for?",
        "What opportunities in your life do you appreciate the most?"
    };

    public GratitudeActivity() 
        : base("Gratitude Activity", "This activity helps you focus on positive aspects of your life by listing things you are grateful for.") 
    { }

    public void Run()
    {
        DisplayStartingMessage();

        // Pick a random gratitude prompt
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("\nTake a few seconds to think about your gratitude list...");

        // Use the spinner animation while the user thinks
        ShowSpinner(5);

        Console.WriteLine("\nStart listing things you are grateful for. Press Enter after each one.");
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

        Console.WriteLine($"\nYou listed {items.Count} things you are grateful for.");
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
