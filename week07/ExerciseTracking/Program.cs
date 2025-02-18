using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 4.8), // Running 4.8 km
            new Biking("05 Nov 2022", 40, 20.0), // Biking 20 kph
            new Swimming("07 Nov 2022", 25, 20)  // Swimming 20 laps
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
