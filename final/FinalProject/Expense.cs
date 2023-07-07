public class Expense{
    string _description;
    float _value;
    string _category;
    string _date;


    public Expense(string description, float value, string category, string date){
        _description = description;
        _value = value;
        _category = category; 
        _date = date;
    }

    public string GetCateogry(){
        return _category;
    }

    public float GetValue(){
        return _value;
    }

    public void displayExpense(){
        Console.WriteLine($"Description:{_description} value:{_value} category{_category} date:{_date}");
    }

    public string strimExpense(){
        return $"{_description},{_value},{_category},{_date}";
      
    }

   
    public static void CreateDocument(string filname, List<Expense> expenses){
        string filePath = AppDomain.CurrentDomain.BaseDirectory + @$"{filname}";
        using (StreamWriter monthFile = new StreamWriter(filePath))
        {   
            foreach ( Expense expense in expenses){
                monthFile.WriteLine(expense.strimExpense());
            }  
        } 
    }


    public static string SelectMonth(int month){
        string filname =" ";
        if(month == 1){
        filname = "january.txt";
        }
        else if(month == 2){
        filname = "february.txt";
        }
        else if(month == 3){
        filname = "march.txt";
        }
        else if(month == 4){
        filname = "april.txt";
        }
        else if(month == 5){
        filname = "may.txt";
        }
        else if(month == 6){
        filname = "june.txt";
        }
        else if(month == 7){
        filname = "july.txt";
        }
        else if(month == 8){
        filname = "august.txt";
        }
        else if(month == 9){
        filname = "september.txt";
        }
        else if(month == 10){
        filname = "october.txt";
        }
        else if(month == 11){
        filname = "november.txt";
        }
        else if(month == 12){
        filname = "december.txt";
        }
        return filname;
    }

    public static void SavePerMonth(List<Expense> expenses)
    {  
        // Get the mont to name the file 
        DateTime currentDateTime = DateTime.Today;
        string dateString = currentDateTime.ToString();
        string[] parts = dateString.Split("/");
        int monthNumber = int.Parse(parts[0]);
        string fileName = SelectMonth(monthNumber);
        CreateDocument(fileName, expenses);
    }

}


    
