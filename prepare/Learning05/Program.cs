using System;
using System.Collections.Generic;

class GoalTracker
{
    static void Main(string[] args)
    {
        GoalList goalList = new GoalList();

        while (true)
        {
            Console.WriteLine("Goal Tracker");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Mark Goal as Complete");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice (1-4):");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter goal description:");
                    string description = Console.ReadLine();
                    goalList.AddGoal(description);
                    Console.WriteLine("Goal added!");
                    Console.WriteLine();
                    break;
                case "2":
                    Console.WriteLine("Goal List:");
                    goalList.DisplayGoals();
                    Console.WriteLine();
                    break;
                case "3":
                    Console.WriteLine("Enter goal index to mark as complete:");
                    int index = Convert.ToInt32(Console.ReadLine());
                    goalList.MarkGoalComplete(index);
                    Console.WriteLine("Goal marked as complete!");
                    Console.WriteLine();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}

class GoalList
{
    private List<string> _goals;

    public GoalList()
    {
        _goals = new List<string>();
    }

    public void AddGoal(string description)
    {
        _goals.Add(description);
    }

    public void MarkGoalComplete(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            _goals.RemoveAt(index);
        }
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i]}");
            }
        }
    }
}
