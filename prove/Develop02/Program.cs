using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine(); 
        Console.WriteLine("Hi There! Welcome to your Daily Journal Program");
        Console.WriteLine();  
        //Create a Journal
        Journal AJournal = new Journal();

        //File loaded by the user
        AJournal._loadedFile ="entries.txt";

        // Set the loop 
        int userResponse = 0;
       

        do{
            Menu menu = new Menu();
            menu.displayMenu(AJournal._loadedFile);
            userResponse = int.Parse(Console.ReadLine());

            // Option 1 Display a promp a prompt from the user and save it in an instance
            if(userResponse == 1){
              menu.Write(AJournal._loadedFile);
            }
             // Display all the Entries from the instance
            else if(userResponse == 2)
            {
              AJournal.DisplayEntries(AJournal._loadedFile);
            }
            //load and display entries from another file 
            else if(userResponse == 3)
            {
              Console.WriteLine();
              Console.WriteLine("1. Create new file.");
              Console.WriteLine("2. Load file.");
              Console.Write("Type an option: ");
              int selection = Int32.Parse(Console.ReadLine());

              if(selection == 1){
                 Console.Write("Name of the new file: ");
                 string fileName = Console.ReadLine(); 
                 using (StreamWriter sw = File.CreateText(fileName))
                  {
                  sw.WriteLine($"----------------- -------------------");
                  }	
                  // load the file created 
                  AJournal._loadedFile = fileName;

              }else
              {
                Console.Write("Name of the file to load: ");
                
                // load the file enteres by the user 
                AJournal._loadedFile = Console.ReadLine(); 
              }
              
            }
            else if(userResponse == 4)
            {
            //Create a file with the user entries
              Console.WriteLine("Program ended, bye and hope to see you,!");

            }

        } while(userResponse != 4);     
    }
}