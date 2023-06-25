public class CheckList : Goal
{
    string _goalType = "CheckList";
    int _times = 0;
    int _timesCompleted = 0;
    int _bonus = 0;

    public CheckList(string name, string description, int value, int times, int bonus, bool iscompleted, int timesCompleted) : base(name, description, value, iscompleted)
    {
        _name = name;
        _description = description;
        _value = value;
        _times = times;
        _bonus = bonus;
        _timesCompleted = timesCompleted;
    }

    public override void DisplayGoal()
    {
        if (_iscompleted)
        {
            _checkMark = "X";
        }
        Console.WriteLine($"[{_checkMark}] {_name} ({_description}) -- Currently completed: {_timesCompleted}/{_times}");
    }

    public override string StrimGoal()
    {
        return $"{_goalType},{_name},{_description},{_value},{_bonus},{_times},{_timesCompleted},{_iscompleted}";
    }

    public override int completeGoal()
    {
        _timesCompleted += 1;
        if (_timesCompleted == _times)
        {
            _iscompleted = true;
            return _value + _bonus;
        }
        else
        {
            return _value;
        }
    }
}
