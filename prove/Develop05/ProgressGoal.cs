using System;

class ProgressGoal : Goal
{
    public int Progress { get; set; }
    public int TargetProgress { get; set; }

    public ProgressGoal(string description, bool isCompleted, int progress, int targetProgress)
        : base(description, isCompleted)
    {
        Progress = progress;
        TargetProgress = targetProgress;
    }

    public override int CompleteGoal()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine("Progress goal marked as complete!");
            return 50; // Adjustable points earned for completing the goal
        }
        else
        {
            Console.WriteLine("Progress goal is already completed.");
            return 0;
        }
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"Progress Goal: {Description} ({Progress}/{TargetProgress})");
    }
}

class NegativeGoal : Goal
{
    public int Penalty { get; set; }

    public NegativeGoal(string description, bool isCompleted, int penalty)
        : base(description, isCompleted)
    {
        Penalty = penalty;
    }

    public override int CompleteGoal()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine("Negative goal marked as complete!");
            return -Penalty; // Subtract the penalty from the score
        }
        else
        {
            Console.WriteLine("Negative goal is already completed.");
            return 0;
        }
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"Negative Goal: {Description} (Penalty: {Penalty})");
    }
}
