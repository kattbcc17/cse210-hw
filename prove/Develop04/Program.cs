using System;
using System.Threading;


class Program
{ 
    static void Main(string[] args)
    {   
        static void DisplayMenu(){
        Console.Clear();    
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. Quit");
        Console.Write("Select a choice from the menu: ");
        }
    
    //Start
    Console.Clear();
    Console.WriteLine("Welcome to the mindfulness program. This program has 3 activities to help you ponder and reflect during the day");
    
        int runProgram = 0;
        while(runProgram != 4){
            DisplayMenu();
            // Read user imput 
            string userSelection = Console.ReadLine();
            //parse imput to int
            int activity = Int32.Parse(userSelection);


            switch(activity)
            {
            //Breathing activity
            case 1:
                Console.Clear();
                Breathing breathing = new Breathing(0,"Breathing");
                breathing.WelcomMesage();
                breathing.displayDescription();
                // store the duration in seconds of the activty 
                int getDuration = breathing.getDuration();
                breathing.pauseProgram(3);
                breathing.Breath(getDuration);
                
            break;

            //Reflecting activity
            case 2:
                Console.Clear();
                Reflecting reflecting = new Reflecting(0,"Refelcting");
                reflecting.WelcomMesage();
                reflecting.displayDescription();
                // store the duration in seconds of the activty 
                getDuration = reflecting.getDuration();
                reflecting.pauseProgram(3);
                reflecting.reflect(getDuration);
            break;
            
            //Reflecting listening
            case 3:
                Console.Clear();
                Listening listening = new Listening(0,"Listening");
                listening.WelcomMesage();
                listening.displayDescription();
                // store the duration in seconds of the activty 
                getDuration = listening.getDuration();
                listening.pauseProgram(3);
                listening.listening(getDuration);
            break;

            //Stop the  program
            case 4:
                runProgram = 4;
            break;
            } 
        }

    }
}