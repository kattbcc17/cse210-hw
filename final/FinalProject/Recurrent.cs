public class Recurrent : Category{

    int _timesSpent;
    public Recurrent(string categoryName, float limit, float spent, bool overBudget, int timesSpent): base (categoryName,  limit,  spent,  overBudget){
        _categoryType = "recurrent";
        _timesSpent = timesSpent;
    }

    public override void displayCategories(int number)
    {
        Console.WriteLine($"{number}. Name: {_name} | limit: ${_limit} | spent: {_spent}");
    }

    public override string StrimCategory()
    {
        return $"{_categoryType},{_name},{_limit},{_spent},{_overBudget},{_timesSpent}";
    }


}