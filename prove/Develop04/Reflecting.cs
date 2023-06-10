public class Reflecting : Activity{

    private List<string> _prompts = new List<string> {
        " --- Think of a time when you did something really difficult. ---",
        "--- Think of a time when someone did somthing special for you ---",
        "--- Think of a time when somthing bad help you to become a better person ---",
        "--- Think of a time when you sacrifice something fun for something more important ---",
        "--- Think of a time when you worked hard for something and you achieved it ---",
        "--- Think of a time when you were desperate but at the end everything was ok ---"
    };

   
    public Reflecting(int activityTime, string activityName) : base( activityTime, activityName){
        
    }

     public void displayDescription(){
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n");
    }

    public string SelectPrompt(){
         Random randomGenerator = new Random();
         int promptIndex = randomGenerator.Next(1,_prompts.Count); 
         string selectedPrompt = _prompts[promptIndex];
         return selectedPrompt;
    }

    public void reflect(int seconds){
        Console.WriteLine("Consider the following Prompt: \n");
        Console.WriteLine(SelectPrompt());
        Console.WriteLine("When you have soemthing in mind, press enter to continue");
        Console.ReadLine();
        Console.WriteLine("Now Ponder on each of the following questions as they related to this experience");
        
        for(int i = 0; i <= 4; i++){
            Console.Write($"You may begin in: {i}");
            Thread.Sleep(1000);
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
        }

        Console.Clear();
        int questionDuration = seconds/2;
        Console.Write("How did you feel when it was complete?");
        Animations.DisplaySpiner(questionDuration);
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("What is your favorite thing about this experience?");
        Animations.DisplaySpiner(questionDuration);
        Console.WriteLine();
        Console.WriteLine();
        DisplayByeMessage();
        Animations.DisplaySpiner(10);
    }

  

}