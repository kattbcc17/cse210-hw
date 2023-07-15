public abstract class Category{
    protected string _name;
    protected float _limit;
    public float _spent;
    protected bool _overBudget; 
    protected string _categoryType;

    public Category (string categoryName, float limit, float spent, bool overBudget){
        _name = categoryName;
        _limit = limit;
        _spent = spent;
        _overBudget = overBudget;
    }

    public string GetName()
    {
        return _name;
    }

    public float Getlimit()
    {
        return _limit;
    }

    public float GetSpent(){

        return _spent;
    }

    public void AddExpense(float spent)
    {
        _spent += spent;
    }

    public string GetType(){
        return _categoryType;
    }

    public abstract void displayCategories(int number);
    public  abstract string StrimCategory();
   
    // loop in to the list of categories of the controller class 
     public static bool loopCateogires(List<Category> _Categories, int _userSelection){
        bool next = false;      
        //Display and alert message acording to the switch case:
        if(_Categories.Count() == 0 && _userSelection == 1){
        Console.WriteLine("**** Alert *****");
        Console.WriteLine("There are no categories to display.\n");
        next = true;
        return next;
        }
        else if(_Categories.Count() == 0 && _userSelection == 2){
        Console.WriteLine("There are no categories created.");
        Console.WriteLine("You need to create a Category before creating an expense.");
        return next;
        }

    else{
        int counter = 1;
        foreach(Category category in _Categories){   
            category.displayCategories(counter);
            counter +=1;
            }
        next = true;
        return next; 
        }
    }

    public static void SaveCategory(string filname, List<Category> cateogries){  
        // Find the Path of the file.
        string filePath = AppDomain.CurrentDomain.BaseDirectory + @"categories.txt";  

            using (StreamWriter outputFile = new StreamWriter(filePath))
            {   
        
                foreach(Category category in cateogries)
                {
                        outputFile.WriteLine(category.StrimCategory());
                }
            } 
    }



    public void SetDate(){
    DateTime currentDateTime = DateTime.Today;
    string dateString = currentDateTime.ToString();
    string[] parts = dateString.Split("/");

    switch(parts[0]){

        case "3":
        break;
    }

    foreach(string part in parts){
        Console.WriteLine(part);
    }

    
    }

} 