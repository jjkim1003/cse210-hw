using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage. ");
        string gradeFromStudent = Console.ReadLine();

        int x = int.Parse(gradeFromStudent);

        if (x >= 90)
        {
            Console.WriteLine ("Your current grade is A. Congraulations!");
        }
        else if (x >= 80)
        {
            Console.WriteLine ("Your current grade is B. Congraulations!");
        }
        else if (x >= 70)
        {
            Console.WriteLine ("Your current grade is C. Congraulations!")
        }
        else if (x >= 60)
        {
            Console.WriteLine ("Your current grade is D. You can pass the course (above C) if you study a little more. ")
        }
        else (x < 60)
        {
            Console.WriteLine ("Your current grade is F. You can pass the course (above C) if you study harder. ")
        }


    }
}