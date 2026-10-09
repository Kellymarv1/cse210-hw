using System;

// -------------------------------------------------------------
// EXCEEDING REQUIREMENTS:
// Added clear feedback messaging and intuitive console prompts 
// throughout the user interface to enhance engagement and motivation 
// while tracking daily spiritual and personal milestones.
// -------------------------------------------------------------

class Program
{
   static void Main(string[] args)
   {


       Console.WriteLine("Hello World! This is the EternalQuest Project.");

       GoalManager manager = new GoalManager();
       manager. Start();
   }
}