public class Simple : Goal
{
    string _goalType = "Simple";

    public Simple(string name, string description, int value, bool iscompleted) : base(name, description, value, iscompleted)
    {
        _name = name;
        _description = description;
        _value = value;
    }

    public override void DisplayGoal()
    {
        if (_iscompleted)
        {
            _checkMark = "X";
        }
        Console.WriteLine($"[{_checkMark}] {_name} ({_description})");
    }

    public override string StrimGoal()
    {
        return $"{_goalType},{_name},{_description},{_value},{_iscompleted}";
    }

    public override int completeGoal()
    {
        _iscompleted = true;
        return _value;
    }
}
