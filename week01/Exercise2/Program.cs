using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        string gradeFromStudent = Console.ReadLine();

        int grade = int.Parse(gradeFromStudent);

        if (grade >= 90)
        {
            Console.WriteLine ("Your grade is A.");
        }
        else if (grade >= 80)
        {
            Console.WriteLine ("Your grade is B.");
        }
        else if (grade >= 70)
        {
            Console.WriteLine ("Your grade is C.");
        }
        else if (grade >= 60)
        {
            Console.WriteLine ("Your  grade is D.");
        }
        else 
        {
            Console.WriteLine ("Your grade is F.");
        }

        if(grade >=70)
        {
            Console.WriteLine ("You passed it! Congratulations!");
        }
    else 
        {
            Console.WriteLine ("Please study harder to pass it next time.");
        }
    }
}