using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity helps you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.") 
    { }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            AnimateBreathing("Breathe In...", 4, clockwise: true);
            AnimateBreathing("Breathe Out...", 4, clockwise: false);
        }

        DisplayEndingMessage();
    }

    private void AnimateBreathing(string message, int seconds, bool clockwise)
    {
        char[] spinner = clockwise ? new char[] { '|', '/', '-', '\\' } : new char[] { '\\', '-', '/', '|' };
        int delay = 200; // Start fast
        int slowdownStep = 50; // Increase delay over time

        Console.Clear();
        Console.WriteLine(message);

        for (int i = 0; i < seconds * 4; i++) // 4 steps per second
        {
            Console.Write($"\r{spinner[i % 4]}"); // Rotate through spinner symbols
            Thread.Sleep(delay);
            delay += slowdownStep; // Gradually slow down
        }

        Console.Write("\r "); // Clear the spinner at the end
    }
}
