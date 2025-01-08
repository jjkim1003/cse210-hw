using System;

class Program
{
    static void Main(string[] args)
    {
        //finished assignment 1
        Console.Write("What is your first name?  ");
        string firstName = Console. ReadLine();

        Console.Write("What is your last name?  ");
        string lastName = Console. ReadLine();
        
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}