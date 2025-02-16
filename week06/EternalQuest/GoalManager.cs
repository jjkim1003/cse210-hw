using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine($"You have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                continue;
            }
            
            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type: 1. Simple  2. Eternal  3. Checklist");
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid input for points.");
            return;
        }

        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("Enter target count: ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid input for target count.");
                    return;
                }
                Console.Write("Enter bonus points: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid input for bonus points.");
                    return;
                }
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        int simpleCount = 0;
        int eternalCount = 0;
        int checklistCount = 0;
        
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string status = goal.IsComplete() ? "[X]" : "[ ]";

            if (goal is SimpleGoal)
                simpleCount++;
            else if (goal is EternalGoal eternalGoal)
            {
                eternalCount++;
                Console.WriteLine($"{i + 1}. {status} {eternalGoal.GetDetailString()} (Recorded {eternalGoal.GetRecordCount()} times)");
                continue;
            }
            else if (goal is ChecklistGoal)
                checklistCount++;
            
            Console.WriteLine($"{i + 1}. {status} {goal.GetDetailString()}");
        }
        
        Console.WriteLine($"Total: {eternalCount} Eternal Goals, {simpleCount} Simple Goals, {checklistCount} Checklist Goals");
    }

    public void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Enter the number of the goal to record an event: ");
        
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal selectedGoal = _goals[index - 1];
        int pointsEarned = selectedGoal.RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"Event recorded! You earned {pointsEarned} points. Total score: {_score}");

        // Update the list to reflect changes immediately
        ListGoalDetails();
    }

    public void SaveGoals()
    {
        try
        {
            Console.Write("Enter file name to save goals (including .txt extension): ");
            string fileName = Console.ReadLine().Trim();

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while saving the file: " + ex.Message);
        }
    }

    public void LoadGoals()
    {
        try
        {
            Console.Write("Enter file name to load goals (including .txt extension): ");
            string fileName = Console.ReadLine().Trim();

            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] lines = File.ReadAllLines(fileName);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                if (parts[0] == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (parts[0] == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (parts[0] == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while loading the file: " + ex.Message);
        }
    }
}
