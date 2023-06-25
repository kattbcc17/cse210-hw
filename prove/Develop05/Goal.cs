public abstract class Goal
{
    protected string _checkMark = " ";
    protected internal string _name;
    protected internal string _description;
    protected int _value;
    protected internal bool _iscompleted;
    

    public Goal(string name, string description, int value, bool iscompleted)
    {
        _name = name;
        _description = description;
        _value = value;
        _iscompleted = iscompleted;
    }

    public abstract void DisplayGoal();
    public abstract string StrimGoal();
    public abstract int completeGoal();
}
