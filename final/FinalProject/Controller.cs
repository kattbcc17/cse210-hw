public class Controller{

//Keep records of all the categories
public static int _userSelection;
public static List<Category> _Categories = new List<Category>();
public static List<Expense> _Expenses = new List<Expense>();
public static void menuController( int selection){

    //Load all the information from the category file to the local lists
    _userSelection = selection;
    
    // Clear the console to continue the program. 
    Console.Clear();
    switch(_userSelection)
    {
        case 1:
        Menues.MenuCategories();
        Console.Write("Please Type an option from the menu: ");
        int option = int.Parse(Console.ReadLine());

        switch(option)
        {

            // Create a new category 
            case 1:
                Menues.CategoriesType();
                Console.Write("Select an option: ");
                int expenseType = int.Parse(Console.ReadLine());
                Console.WriteLine("\nPlease Type:");
                Console.Write("Name of the category: ");
                string categoryName = Console.ReadLine();
                Console.Write("Set a budget limit for this caregory: $");
                float amount = float.Parse(Console.ReadLine());
                if(expenseType == 1){
                oneTime newCategory = new oneTime(categoryName,amount, 0, false);
                _Categories.Add(newCategory);
                }
                else if(expenseType == 2){
                Recurrent newCategory = new Recurrent(categoryName,amount, 0, false, 0);
                _Categories.Add(newCategory);
                } 
                // Create a file with categories 
                Category.SaveCategory("categories.txt", _Categories);
                Console.WriteLine($"\nNew Category \"{categoryName}\" Saved!");

            break;
            
            // Display existing categories
            case 2:
            Console.Clear();
            Category.loopCateogires(_Categories, _userSelection);
            break;
            
            // Delete Cateogories
            case 3:
                Console.Clear();
                Category.loopCateogires(_Categories, _userSelection);  
                Console.Write("\nSelect the category that you want to delete: ");
                option = int.Parse(Console.ReadLine());
                int oneCounter = 1;
                        for (int i = 0; i < _Categories.Count; i++)
                        {
                            Category category = _Categories[i];
                            if (option == oneCounter){  
                        Console.WriteLine($"category \"" + category.GetName() +"\" was Removed!") ;            
                       _Categories.Remove(category);

                    }
                    oneCounter += 1;
                } 
                //Rewrite the document
                Category.SaveCategory("categories.txt", _Categories);       
            break;

            case 4:
            // Exit to the main menu
            break;
        }
        break;


        // Add Expenses 
        case 2:
        
        // Console.WriteLine("1. Pay one time expences");
        // Console.WriteLine("2. Add a recurrent payment");
        // Console.Write("Select an option: ");
        // int paymentOption = int.Parse(Console.ReadLine());

        // if(paymentOption == 1){

        // foreach(Category category in _Categories){

        //     if(category.GetType() == "oneTime"){
        //         Console.WriteLine();
        //     }
        // }

        // }
        
        
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine();    
         bool continuar = Category.loopCateogires(_Categories, _userSelection);
        if(!continuar){
        break;
        }

        Console.Write("\nSelect one of the categories: ");
        selection = int.Parse(Console.ReadLine());
        int twoCounter = 1;
        string selectedCategory =" ";
        foreach(Category category in _Categories){
            if(twoCounter == selection)
            {
                selectedCategory = category.GetName();          
            }
            twoCounter += 1;
        }

        // Store the Date of the expense 
        Console.Write("Expense Description: ");
        string description = Console.ReadLine();
        Console.Write("Expense amount: $");
        int value = int.Parse(Console.ReadLine());
        DateTime date = DateTime.Today;
        string dateString = date.ToString();
        Expense newExpnese = new Expense(description,value,selectedCategory,dateString);

        // Add the expense to the expense list. 
        _Expenses.Add(newExpnese);
        Console.WriteLine("you expense is saved!");
        Expense.SavePerMonth(_Expenses);

        // Recalculate the Expenses based on categories 
        Controller.MakeExpenseCaculations();
        

        break;

        // Read expences from file and display to the customer
        case 3:
        Menues.monthsMenu();
        Console.Write("Select by number: ");
        int slectedMonth = int.Parse(Console.ReadLine());
        string monthFile = Expense.SelectMonth(slectedMonth);
        Console.Clear();
        Console.WriteLine("\n");

        //Verirfy if the file exist 
        string filePath = AppDomain.CurrentDomain.BaseDirectory + @$"{monthFile}";
        if(File.Exists(filePath)){

            string[] lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
            string[] parts = line.Split(",");
            string expenseDescription = parts[0];
            int expenseValue = int.Parse(parts[1]);
            string category = parts[2];
            string expenseDate = parts[3];

            Console.WriteLine(expenseDate);
            Console.WriteLine($"category: {category}");
            Console.WriteLine(expenseDescription);
            Console.WriteLine($"Value: ${expenseValue}");
            Console.WriteLine("----------------------------------------");
            
            }   
        }
        else{
            Console.WriteLine("************************************");
            Console.WriteLine("THere is not records for this month");
        }

        break;

        case 4:

            foreach(Category category in _Categories){

                if(category.Getlimit() < category.GetSpent()){
                    Console.WriteLine($"\n OVERBUDGET {category.GetName()} - Limit : {category.Getlimit()} | {category._spent}"); 
                }
               
            }
        break;

        case 5:
        float total = 0;
        float totalLimit = 0;
        foreach (Expense expense in _Expenses)
        {
            total += expense.GetValue();
            
        }
        foreach (Category category in _Categories)
        {
            totalLimit += category.Getlimit();
        }

        Console.WriteLine("Account summary");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Month budget: ${totalLimit}");
        Console.WriteLine($"Total Month Spent: ${total}");
        Console.WriteLine();
        Console.WriteLine("Categories description");

        foreach(Category category in _Categories){
        Console.WriteLine($"{category.GetName()} - Limit : ${category.Getlimit()} | ${category._spent}"); 
        }
        break;
    }; 
} 

public static void initializeCategories(){
    string filePath= AppDomain.CurrentDomain.BaseDirectory + @"categories.txt" ;
    
        string[] lines = System.IO.File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            string type = parts[0];
            string name = parts[1];
            float limit = float.Parse(parts[2]);
            float spent = float.Parse(parts[3]);
            bool overBudget = bool.Parse(parts[4]);

            if(type == "oneTime"){ 

                bool isPaid = bool.Parse(parts[5]);
                oneTime category = new oneTime(name,limit, spent, overBudget);
                _Categories.Add(category);
            }
            else if(type == "recurrent"){
            
                int timesSpent = int.Parse(parts[5]);
                Recurrent category = new Recurrent(name,limit, spent, overBudget, timesSpent);
                _Categories.Add(category);

            }
    
        }   
    }

public static string Getmonth(){
    DateTime currentDateTime = DateTime.Today;
    string dateString = currentDateTime.ToString();
    string[] parts = dateString.Split("/");
    int monthNumber = int.Parse(parts[0]);
    string fileName = Expense.SelectMonth(monthNumber);
    return fileName;
}


public static void initializeExpenses(string filename){
     string filePath= AppDomain.CurrentDomain.BaseDirectory + @$"{filename}" ;
     string[] lines = System.IO.File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
          string[] parts = line.Split(",");
          string description = parts[0];
          int value = int.Parse(parts[1]);
          string category = parts[2];
          string date = parts[3];
          Expense newExpnese = new Expense(description,value,category,date);
          _Expenses.Add(newExpnese);
        }   
    }   

    public static void MakeExpenseCaculations() {
        
          // Restart the count from 0 to add the expenses
          foreach(Category category in _Categories){
            category._spent = 0;
          }

          foreach(Category category in _Categories){

            string categorySample = category.GetName();
            
            foreach(Expense expense in _Expenses)
            {
                
                if (categorySample == expense.GetCateogry()){
                    category._spent +=  expense.GetValue();
                }
            }

         }
    }
}

