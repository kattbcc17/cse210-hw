public class Listening : Activity{

    private List<string> _prompts = new List<string> {
        " --- Who are people that you appreciate? ---",
        "--- What are personal strengths of yours? ---",
        "--- Who are people that you have helped this week ---",
        "--- When have you felt the Holy Ghost this month ---",
        "--- Who are some of your personal heroes ---",
    };

    public Listening(int activityTime, string activityName) : base( activityTime, activityName){
        
    }

     public void displayDescription(){
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n");
    }

    public string SelectPrompt(){
         Random randomGenerator = new Random();
         int promptIndex = randomGenerator.Next(1,_prompts.Count); 
         string selectedPrompt = _prompts[promptIndex];
         return selectedPrompt;
    }

    public void listening(int seconds){
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine(SelectPrompt());

        for(int i = 0; i <= 4; i++){
            Console.Write($"You may begin in: {i}");
            Thread.Sleep(1000);
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
        }
        Console.WriteLine();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        DateTime currentTime = DateTime.Now;
        int counter = 0;
        while(currentTime < futureTime)
        {
            Console.Write(">");
            Console.ReadLine();
            currentTime = DateTime.Now;
            counter += 1;
        }
        
        Console.WriteLine($"you listed {counter} items!");
        Console.WriteLine();
        DisplayByeMessage();
        Animations.DisplaySpiner(10);

}

}