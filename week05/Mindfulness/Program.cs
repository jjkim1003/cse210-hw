using System;

class Program
{
    static void Main(string[] args)
    {
        string choice;
        do
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Start gratitude activity");
            Console.WriteLine(" 5. Quit");
            Console.Write("Select a choice from the menu: ");
            
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();
            }
            else if (choice == "4")
            {
                GratitudeActivity gratitudeActivity = new GratitudeActivity();
                gratitudeActivity.Run();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
                Thread.Sleep(2000);
            }
        }
        while (choice != "5");
    }
}
