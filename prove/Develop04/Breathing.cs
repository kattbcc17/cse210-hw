public class Breathing : Activity{
    
    public Breathing(int activityTime, string activityName) : base(activityTime, activityName){

    }   

    public void displayDescription(){
        Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.\n");
    }

    public void Breath(int seconds){  
    // making a jump line before starting the activity    
    Console.WriteLine();
    int secondsTracker = 0;
        while (secondsTracker < seconds){

            for(int i = 0; i < 4; i++){
            Console.Write($"Breath in...{i}");
            Thread.Sleep(1000);
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b");
            secondsTracker += 1;
        }
            // Last breath in prompt 
            Console.WriteLine($"Breath in...4");

            for(int i = 0; i < 6; i++){
            Console.Write($"Breath out...{i}");
            Thread.Sleep(1000);
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
            secondsTracker += 1; 
        }   
            // Last breath out prompt
            Console.WriteLine($"Breath out...6");
            Console.WriteLine();
        }
       
       Console.WriteLine("\n");
       // Display Teh spinner at the end of the program
       DisplayByeMessage();
       Animations.DisplaySpiner(10);
       Console.Clear(); 
       
    }

}