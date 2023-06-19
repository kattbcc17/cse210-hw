using System;
using System.IO;

class Program
{
    private static List<Goal> _allGoals = new List<Goal>();
    private static int total_points = 0;
    static void Main(string[] args)
    {

        
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("");
            Console.WriteLine($"You have {total_points} points.");
            Console.WriteLine("");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create a New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("What would like to do? ");
            int prompt = int.Parse(Console.ReadLine() ?? "");
            if (prompt == 6)
            {
                loop = false;
            }
            else if (prompt == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("The types of Goals are:");
                Console.WriteLine("  1. Simple Goal");
                Console.WriteLine("  2. Eternal Goal");
                Console.WriteLine("  3. Checklist Goal");
                Console.Write("Which type of goal would you like to create? ");
                int answer = int.Parse(Console.ReadLine() ?? "");
                if (answer == 1)
                {
                    Console.Write("What is the name of your goal? ");
                    string goal = Console.ReadLine() ?? "";
                    Console.Write("What is a short description of it? ");
                    string describe = Console.ReadLine() ?? "";
                    Console.Write("What is the amount of points associated with this goal? ");
                    int points = int.Parse(Console.ReadLine() ?? "");
                    Simple simple = new Simple(points, goal, describe);
                    _allGoals.Add(simple);



                }
                else if (answer == 2)
                {
                    Console.Write("What is the name of your goal? ");
                    string goal = Console.ReadLine() ?? "";
                    Console.Write("What is a short description of it? ");
                    string describe = Console.ReadLine() ?? "";
                    Console.Write("What is the amount of points associated with this goal? ");
                    int points = int.Parse(Console.ReadLine() ?? "");
                    Eternal eternal = new Eternal(points, goal, describe);
                    _allGoals.Add(eternal);
                }
                else if (answer == 3)
                {
                    Console.Write("What is the name of your goal? ");
                    string goal = Console.ReadLine() ?? "";
                    Console.Write("What is a short description of it? ");
                    string describe = Console.ReadLine() ?? "";
                    Console.Write("What is the amount of points associated with this goal? ");
                    int points = int.Parse(Console.ReadLine() ?? "");
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int quantity = int.Parse(Console.ReadLine() ?? "");
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine() ?? "");
                    Checklist checklist = new Checklist(points, goal, describe, quantity, bonus, 0);
                    _allGoals.Add(checklist);
                }
            }
            else if (prompt == 2)
            {
                if (_allGoals.Count == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You don't have any goals yet");
                }
                else
                {
                    int numb = 1;
                    foreach (var goal in _allGoals)
                    {


                        Console.Write($"     {numb}. ");
                        Console.WriteLine(goal.Display());
                        numb++;

                    }
                }
                Animation();


            }
            else if (prompt == 3)
            {
                Save();
            }
            else if (prompt == 4)
            {
                Load();
            }
            else if (prompt == 5)
            {
                if (_allGoals.Count == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You don't have any goals yet");
                }
                else
                {
                    int numb = 1;
                    foreach (var goal in _allGoals)
                    {
                        Console.Write($"     {numb}. ");
                        Console.WriteLine(goal.Display());
                        numb++;
                        
                    }
                    Console.Write("Which goal did you accomplish? ");
                    int index = int.Parse(Console.ReadLine() ?? "");
                    var points = _allGoals[index - 1].RecordEvent();
                    total_points += points; 
                }
            }
        }

    }

  

    static void Save()
    {
        string fileName;
        Console.Write("What is the filename for the goal file? ");
        fileName = Console.ReadLine() ?? "";

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {   
            int total_points = 0; 
            outputFile.WriteLine($"{total_points}");
            foreach (Goal entry in _allGoals)
            {
                
                outputFile.WriteLine($"{entry.SaveGoals()}");


            }
        }
    }
    static void Load(){
        string filename;
        Console.Write("What is the filename? ");
        filename = Console.ReadLine() ??""; 
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("@");
            string type = parts[0];
            
            if (type == "Simple") {
                Simple goal = new Simple(Int32.Parse(parts[4]),parts[2], parts[3]);
                goal.SetComplete(parts[1] == "X");
                _allGoals.Add(goal);
            }
            else if (type == "Eternal"){
                Eternal goal = new Eternal(Int32.Parse(parts[4]), parts[2], parts[3]); 
                goal.SetComplete(parts[1] == "X");   
                _allGoals.Add(goal);          
            }
            else if(type == "Checklist") {
                Checklist goal = new Checklist(Int32.Parse(parts[6]), parts[2], parts[3],Int32.Parse(parts[5]), Int32.Parse(parts[7]), Int32.Parse(parts[4]));
                goal.SetComplete(parts[1] == "X");
                _allGoals.Add(goal);

            }


        }

    }
    static void Animation() {

        List<string> animations = new List<string>();
        animations.Add("|");
        animations.Add("/");
        animations.Add("-");
        animations.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(5);

        int i = 0;

        while (DateTime.Now < futureTime)
        {
            string a = animations[i];
            Console.Write(a);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i >= animations.Count)
            {
                i = 0;
            }
        }
        }
        
    }
class Goal {
    protected int _points;
    protected string _goal;
    protected string _description;
    protected bool _complete = false;
    

    public Goal(int points, string goal, string description)
    {
        _points = points;
        _description = description;
        _goal = goal;
        


    }
    virtual public string Display()
    {
        return "";
    }
    virtual public string SaveGoals()
    {
        return "";
    }
    virtual public int RecordEvent(){
        return _points;
    }   
   

    virtual public bool IsComplete()
    {
        _complete = true;
        return _complete;
    }
    virtual public string DisplayGoalName() {
        return $"{_goal}";
    }
    virtual public bool GetComplete() {
        return _complete;
    }
    virtual public void SetComplete(bool complete) {
        _complete = complete;
    }
}

class Simple : Goal
{

    public Simple(int points, string goal, string description) : base(points, goal, description)
    {
       
    }
    public override string Display()
    {
        string checkmark = " ";
        if (_complete)
        {
            checkmark = "X";
        }
        return $"[{checkmark}] {_goal} ({_description})";
    }
    public override string SaveGoals()
    {
        string checkmark = "O";
        if (_complete)
        {
            checkmark = "X";
        }
        return $"Simple@{checkmark}@{_goal}@{_description}@{_points}";
    }
    public override int RecordEvent()
    {
        _complete = true; 
        Console.WriteLine($"You accomplished this Simple goal and earned {_points} points.");
        return _points;
        

        
    }
    public override string DisplayGoalName()
    {
        return base.DisplayGoalName();
    }

    public override bool IsComplete()
    {
        _complete = false;
        return _complete;
    }

}

class Eternal : Goal
{
    public Eternal(int points, string goal, string description) : base(points, goal, description)
    {
        
    }
    public override string Display()
    {
        string checkmark = " ";
        if (_complete)
        {
            checkmark = "X";
        }

        return $"[{checkmark}] {_goal} ({_description})";
    }
    public override string SaveGoals()
    {   
        string checkmark = "O";
        if (_complete)
        {
            checkmark = "X";
        }
        return $"Eternal@{checkmark}@{_goal}@{_description}@{_points}";
    }
    public override string DisplayGoalName() {
        return base.DisplayGoalName();
    }
    public override int RecordEvent()
    {
        base.RecordEvent();
        _complete = false;
        Console.WriteLine($"You accomplished this Eternal goal and earned {_points} points.");
        return _points;
    }

}

class Checklist : Goal {
    private int _quantity;
    private int _bonus;
    private int _accomplished;
    public Checklist(int points, string goal, string description, int quantity, int bonus, int accomplished) : base(points, goal, description)
    {
        _quantity = quantity;
        _bonus = bonus;
        _accomplished = accomplished;
       

    }
    public override string Display()
    {
        string checkmark = " ";
        if (_complete)
        {
            checkmark = "X";
        }
        return $"[{checkmark}] {_goal} ({_description}) ---Currently completed: {_accomplished}/{_quantity}";
    }
    public override string SaveGoals()
    {
        string checkmark = "O";
        if (_complete)
        {
            checkmark = "X";
        }
        return $"Checklist@{checkmark}@{_goal}@{_description}@{_accomplished}@{_quantity}@{_points}@{_bonus}";
    }
     public override string DisplayGoalName()
    {
        return base.DisplayGoalName();
    }
    public override bool IsComplete()
    {
        _complete = false;
        return _complete;
    }

    public override int RecordEvent()
    {
        
        if (_accomplished != _quantity - 1) {
            _accomplished += 1;
            Console.WriteLine($"You accomplished this Checklist goal and earned {_points} points.");
            return _points; 
        }
        else if (_accomplished == _quantity - 1) {
            _accomplished += 1;
            _complete = true;
            Console.WriteLine($"You accomplished this Checklist goal and earned {_bonus} the bonus points.");
            return _bonus;
        }
        else {
            return 0; 
        }
    }
}
