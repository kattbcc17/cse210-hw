using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {   Console.Clear();
        Animations.DisplayAnimation();
        
        string filePath = AppDomain.CurrentDomain.BaseDirectory + @"categories.txt";
        if (File.Exists(filePath)){
            Controller.initializeCategories();
        }
               
        // Controller.initializeCategories();
        string filename = Controller.Getmonth();
        
        filePath = AppDomain.CurrentDomain.BaseDirectory + @$"{filename}";
        if(File.Exists(filePath)){
            Controller.initializeExpenses(filename);
        
            Controller.MakeExpenseCaculations();
        }  
       
        Console.Clear();
        // Program Wellcome Message
        Console.WriteLine("Welcome to this expenses tracking program");
        Console.WriteLine("This program will allow you to create different budget categories and add expenses to each one of the categories");
        Console.WriteLine("You will also be able to review past expenses monthly reports and useful information about your budget \n");  


        //Run the program infite times 
        int userSelection = 0;
        while(userSelection != 6){
        
        Menues.DisplayMain();
        Console.Write("Select and option from the menu: ");
        userSelection = int.Parse(Console.ReadLine());
        Controller.menuController(userSelection);
        };
        // End of the program 
        Console.WriteLine("The program is over");   

    }
}