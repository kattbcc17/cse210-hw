public class Expense
{
    private string _description;
    private float _value;
    private string _category;
    private string _date;

    public Expense(string description, float value, string category, string date)
    {
        _description = description;
        _value = value;
        _category = category;
        _date = date;
    }

    public string GetCategory()
    {
        return _category;
    }

    public float GetValue()
    {
        return _value;
    }

    public void DisplayExpense()
    {
        Console.WriteLine($"Description: {_description} Value: {_value} Category: {_category} Date: {_date}");
    }

    public string StrimExpense()
    {
        return $"{_description},{_value},{_category},{_date}";
    }

    public static void CreateDocument(string filename, List<Expense> expenses)
    {
        string filePath = AppDomain.CurrentDomain.BaseDirectory + @$"{filename}";
        using (StreamWriter monthFile = new StreamWriter(filePath))
        {
            foreach (Expense expense in expenses)
            {
                monthFile.WriteLine(expense.StrimExpense());
            }
        }
    }

    public static string SelectMonth(int month)
    {
        string filename = string.Empty;
        switch (month)
        {
            case 1:
                filename = "january.txt";
                break;
            case 2:
                filename = "february.txt";
                break;
            case 3:
                filename = "march.txt";
                break;
            case 4:
                filename = "april.txt";
                break;
            case 5:
                filename = "may.txt";
                break;
            case 6:
                filename = "june.txt";
                break;
            case 7:
                filename = "july.txt";
                break;
            case 8:
                filename = "august.txt";
                break;
            case 9:
                filename = "september.txt";
                break;
            case 10:
                filename = "october.txt";
                break;
            case 11:
                filename = "november.txt";
                break;
            case 12:
                filename = "december.txt";
                break;
            default:
                throw new ArgumentException("Invalid month number");
        }
        return filename;
    }

    public static void SavePerMonth(List<Expense> expenses)
    {
        DateTime currentDateTime = DateTime.Today;
        string dateString = currentDateTime.ToString();
        string[] parts = dateString.Split("/");
        int monthNumber = int.Parse(parts[0]);
        string fileName = SelectMonth(monthNumber);
        CreateDocument(fileName, expenses);
    }
}
