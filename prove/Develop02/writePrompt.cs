public class WritePrompt{
    private DisplayEntries _writtenEntries;
    public WritePrompt(DisplayEntries writtenEntries) {
        _writtenEntries = writtenEntries;
    }
    public List<string> _questions = new List<string>(){
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was something I didn't like today?",
        "What was the biggest challenge I had today?"
    };
    DateTime today = DateTime.Today;
    public string _displayPrompt(){
        Random randomnum = new Random();
        int rng = randomnum.Next(6);
        string promptQuestion = (_questions[rng]);
        Console.WriteLine(promptQuestion);
        string promptAnswer = Console.ReadLine();
        string getDate = today.ToString("MM/dd/yyyy");

        string combinedEntry = ($"{getDate} | {promptQuestion} {promptAnswer}");
        
        _writtenEntries._entries.Add(combinedEntry);
        return combinedEntry;
    }
}