public static class GoalFactory
{
    public static int GoalMenu()
    {
        Console.WriteLine("The types of Goals are: ");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Check list");
        Console.WriteLine("4. Progress Goal");
        Console.WriteLine("5. Negative Goal");
        Console.Write("Which type of goal would you like to create?: ");
        int value = int.Parse(Console.ReadLine());
        return value;
    }

    // Create Simple Goals
    public static Goal CreateSimple()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("Type a short description of your goal: ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int value = int.Parse(Console.ReadLine());
        Simple simpleGoal = new Simple(name, description, value, false);
        return simpleGoal;
    }

    // Create Eternal Goals
    public static Goal CreateEternal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("Type a short description of your goal: ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int value = int.Parse(Console.ReadLine());
        Eternal eternalGoal = new Eternal(name, description, value, false);
        return eternalGoal;
    }

    // Create Check List Goals
    public static Goal CreateCheckList()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("Type a short description of your goal: ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int value = int.Parse(Console.ReadLine());
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        int times = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        int bonus = int.Parse(Console.ReadLine());
        CheckList checkListGoal = new CheckList(name, description, value, times, bonus, false, 0);
        return checkListGoal;
    }

    public static Goal CreateProgress()
    {
        Console.WriteLine("Enter the description of the goal:");
        string description = Console.ReadLine();
        Console.WriteLine("Enter the progress achieved:");
        int progress = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the target progress:");
        int targetProgress = Convert.ToInt32(Console.ReadLine());
        return new ProgressGoal(description, false, progress, targetProgress);
    }

    public static Goal CreateNegative()
    {
        Console.WriteLine("Enter the description of the goal:");
        string description = Console.ReadLine();
        Console.WriteLine("Enter the penalty:");
        int penalty = Convert.ToInt32(Console.ReadLine());
        return new NegativeGoal(description, false, penalty);
    }

}
