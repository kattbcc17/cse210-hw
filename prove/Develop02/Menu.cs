public class Menu{

   
public void displayMenu(string fileName){
    Console.WriteLine();
    Console.WriteLine("Please select one of the following choices: ");
    Console.WriteLine($"The file loaded is: {fileName} ");
    Console.WriteLine("1. Write");
    Console.WriteLine("2. Display");
    Console.WriteLine("3. Change file");
    Console.WriteLine("4. Quit");
    Console.Write("What would you like to do? ");
}

public void Write(string loadedFile ){
    PromptGenerator dailyPrompt = new PromptGenerator();

    //

    // get a random number index from the list 
    int promptIndex = dailyPrompt.selectPrompt();
    Console.WriteLine();

    // store the prompt in variable 
    string prompt = dailyPrompt._promptPool[promptIndex];
    
    // Display prompt on Screen
    Console.WriteLine(prompt);

    // Create a new Entrey isntance 
    Entry newEntry = new Entry();

    // Store entry information in the new instance  
    newEntry.storeDate();
    newEntry._prompt = prompt;
    newEntry._userEntry = Console.ReadLine();
    Console.WriteLine();
    
    // Return the object of the new entry
    Journal NJournal = new Journal();
    NJournal._fileName ="entries.txt";
    string filePath= AppDomain.CurrentDomain.BaseDirectory + @$"{NJournal._fileName}" ;
    NJournal._filePath = filePath;
    NJournal.saveEntry(newEntry, loadedFile);
}

}