public class PromptGenerator{

    // List of the promts     
    public List<string> _promptPool = new List<string>(){
    "Who was the most interesting person I interacted with today?",
    "What was the funniest thing today?",
    "What was the best part of my day?",
    "How did I see the hand of the Lord in my life today?",
    "What was the strongest emotion I felt today?",
    "What was my favorite meal of the day?",
    "If I had one thing I could do over today, what would it be?",
    "The best conversation today was about:",
    };

    // Store the index of the promtpt
    public int _promtIndex;

    // Store the index of the promtpt
    public string _promtText;

    //Constructor
    public PromptGenerator(){
    
    }

    //create a random number based in the length of the list
    public int selectPrompt(){
        Random randomGenerator = new Random();
        _promtIndex = randomGenerator.Next(1,_promptPool.Count); 
        return _promtIndex;
            
    }
    //Store the Text of the prompt in the atribute _promtText
    public void StorePrompt(int promtIndex){
        _promtText = _promptPool[promtIndex];
    }
  
}