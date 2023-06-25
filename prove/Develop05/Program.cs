using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    // Store all the goals
    public static List<Goal> GoalList = new List<Goal>();

    // Keep track of the score
    public static int score = 0;

    // File name variable
    public static string filename;

    static void Main(string[] args)
    {
        DateTime today = DateTime.Today;

        while (true)
        {
            DisplayMenu();

            Console.WriteLine("Enter your choice (1-6):");
            string userSelection = Console.ReadLine();
            Console.WriteLine();

            switch (userSelection)
            {
                case "1":
                    int selection = GoalFactory.GoalMenu();
                    switch (selection)
                    {
                        case 1:
                            GoalList.Add(GoalFactory.CreateSimple());
                            break;
                        case 2:
                            GoalList.Add(GoalFactory.CreateEternal());
                            break;
                        case 3:
                            GoalList.Add(GoalFactory.CreateCheckList());
                            break;
                        default:
                            Console.WriteLine("Invalid goal type. Please try again.");
                            break;
                    }
                    Console.WriteLine("Goal created!");
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine("Goal List:");
                    DisplayGoals();
                    break;

                case "3":
                    Console.Write("Enter the name of the file: ");
                    filename = Console.ReadLine();
                    SaveGoals(filename);
                    break;

                case "4":
                    Console.Write("Enter the name of the file: ");
                    filename = Console.ReadLine();
                    score = LoadGoals(filename);
                    break;

                case "5":
                    Console.WriteLine("The Goals are: ");
                    DisplayGoals();
                    Console.WriteLine("Enter the goal index to mark as complete:");
                    int index = Convert.ToInt32(Console.ReadLine());
                    if (index >= 0 && index < GoalList.Count)
                    {
                        Goal goal = GoalList[index];
                        int earnedPoints = goal.completeGoal();
                        score += earnedPoints;
                        Console.WriteLine("Goal marked as complete!");
                        Console.WriteLine($"Congratulations! You earned {earnedPoints} points.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal index. Please try again.");
                    }
                    Console.WriteLine();
                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Goal Tracker");
        Console.WriteLine($"Today is {DateTime.Today.ToString("MM/dd/yyyy")}");
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Exit Program");
    }

    static void DisplayGoals()
    {
        int number = 1;
        foreach (Goal goal in GoalList)
        {
            Console.Write($"{number}. ");
            goal.DisplayGoal();
            number++;
        }
        Console.WriteLine();
    }

    static void SaveGoals(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Goal goal in GoalList)
            {
                outputFile.WriteLine($"{goal.GetType().Name},{goal._description},{goal._iscompleted}");
            }
            outputFile.WriteLine(score);
        }
        Console.WriteLine($"Goals saved to {fileName}!");
        Console.WriteLine();
    }

    static int LoadGoals(string filename)
    {
        List<Goal> goalist = new List<Goal>();
        int score = 0;

        // Load goals from the file and update the goalist and score variables

        return score;
    }

}
