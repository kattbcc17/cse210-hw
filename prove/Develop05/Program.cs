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
                int number = 1;
                foreach( Goal goal in GoalList){
                    Console.Write($"{number}. ");
                    goal.DisplayGoal();
                    number += 1;
                }
                    break;

                case "3":
                    Console.Write("Enter the name of the file: ");
                    filename = Console.ReadLine();
                    FileManager.SaveGoals(filename, GoalList, score);
                    SaveGoals(filename);
                    break;

                case "4":
                    Console.Write("Enter the name of the file: ");
                    filename = Console.ReadLine();
                    score = FileManager.LoadGoals(filename, GoalList, score);
                    break;

                case "5":
                    Console.WriteLine("The Goals are: ");
                    number = 1;
                    // Numerate the goal 
                    foreach(Goal goal in GoalList){
                        Console.Write($"{number}. ");
                        goal.DisplayGoal();
                        number += 1;
                    }
                    Console.Write("Which Goal did you acomplish? ");
                    int selectedGoal = int.Parse(Console.ReadLine());
                    
                    number = 1;
                    foreach(Goal goal in GoalList){
                    // Compare the number of the goal with the user selection    
                        if (selectedGoal == number){
                        int earnedPorints = goal.completeGoal();
                        score += earnedPorints;
                        Console.WriteLine($"*****************************************"); 
                        Console.WriteLine($"Congratulations you earned {earnedPorints}");

                    }
                    else
                    {
                        Console.WriteLine("Invalid goal index. Please try again.");
                    }
                    Console.WriteLine();
                }

                    break;

                case "6":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }

             // Add a small delay for the animation effect
            Thread.Sleep(1000);
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {score} points ");   
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
