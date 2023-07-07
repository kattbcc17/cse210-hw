public class oneTime : Category{

    bool _isPaid = false;
    public oneTime(string categoryName, float limit, float spent, bool overBudget): base ( categoryName,  limit,  spent,  overBudget){
        _categoryType = "oneTime";
    }

    public override void displayCategories(int number)
    {
        Console.WriteLine($"{number}. Name: {_name} | limit: ${_limit} | spent: {_spent}");
    }

      public override string StrimCategory()
    {
        return $"{_categoryType},{_name},{_limit},{_spent},{_overBudget},{_isPaid}";
    }

}