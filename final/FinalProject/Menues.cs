public static class Menues
{
    // Main menu
    public static void DisplayMain()
    {
        Console.WriteLine("\n1. Manage Categories");
        Console.WriteLine("2. Add Expenses");
        Console.WriteLine("3. Expenses History");
        Console.WriteLine("4. OverBudget Categories");
        Console.WriteLine("5. Account Summary");
        Console.WriteLine("6. Exit");
    }

    public static void MenuCategories()
    {
        Console.WriteLine("1. Create Categories");
        Console.WriteLine("2. Display Categories");
        Console.WriteLine("3. Remove Category");
        Console.WriteLine("4. Back");
    }

    public static void CategoriesType()
    {
        Console.WriteLine("\nSelect category type");
        Console.WriteLine("1. One-time");
        Console.WriteLine("2. Recurrent");
    }

    public static void MonthsMenu()
    {
        Console.WriteLine("\nSelect month");
        Console.WriteLine("1. January");
        Console.WriteLine("2. February");
        Console.WriteLine("3. March");
        Console.WriteLine("4. April");
        Console.WriteLine("5. May");
        Console.WriteLine("6. June");
        Console.WriteLine("7. July");
        Console.WriteLine("8. August");
        Console.WriteLine("9. September");
        Console.WriteLine("10. October");
        Console.WriteLine("11. November");
        Console.WriteLine("12. December");
    }
}
