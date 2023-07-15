public static class Menues{

     //Main menu 
        public static void DisplayMain(){
        Console.WriteLine("\n1. Manage Categories");
        Console.WriteLine("2. Add Expenses");  
        Console.WriteLine("3. Expenses History");
        Console.WriteLine("4. OverBudget categories");
        Console.WriteLine("5. Account summary");
        Console.WriteLine("6. Exit");
        }

        public static void MenuCategories(){
        Console.WriteLine("1. Create Categories");
        Console.WriteLine("2. Display Categories");  
        Console.WriteLine("3. Remove Categorie");
         Console.WriteLine("4. Back");
        }

        public static void CategoriesType(){
        Console.WriteLine("\nSelect category type");        
        Console.WriteLine("1. one time");
        Console.WriteLine("2. Recurrent");  
        }

        public static void monthsMenu(){
        Console.WriteLine("\nSelect month");        
        Console.WriteLine("1. january");
        Console.WriteLine("2. february");
        Console.WriteLine("3. march");
        Console.WriteLine("4. april");
        Console.WriteLine("5. may");
        Console.WriteLine("6. june");
        Console.WriteLine("7. july");
        Console.WriteLine("8. august");
        Console.WriteLine("9. september");
        Console.WriteLine("10. october");
        Console.WriteLine("11. november");
        Console.WriteLine("12. december");
        }


}