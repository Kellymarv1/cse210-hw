using System;
using System.Collections.Generic;

// EXCEEDING REQUIREMENTS:
// 1. Scripture Library: Instead of hardcoding a single scripture, this program 
//    maintains a collection of multiple scriptures (including single verses and verse ranges) 
//    and selects one at random each time the program runs.
// 2. Stretch Challenge: The program implements the stretch requirement to select 
//    random words exclusively from the pool of words that are not already hidden.

class Program
{
   static void Main(string[] args)
   {
       Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
       // Create a library of scriptures
       List<Scripture> scriptureLibrary = new List<Scripture>
       {
           new Scripture(
               new Reference("Proverbs", 3, 5, 6),
               "Trust in the Lord with all thine heart and lean not unto thine own understanding"
           ),
           new Scripture(
               new Reference("John", 3, 16),
               "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"
           ),
           new Scripture(
               new Reference("Mosiah", 2, 17),
               "When ye are in the service of your fellow beings ye are only in the service of your God"
           )
       };

       // Select a random scripture from the library
       Random random = new Random();
       Scripture currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

       // Main program loop
       while (true)
       {
           Console.Clear();
           Console.WriteLine(currentScripture.GetDisplayText());
           Console.WriteLine();

           // Check if all words are hidden to end the program naturally
           if (currentScripture.IsCompletelyHidden())
           {
               Console.WriteLine("All words are hidden. Great job memorizing!");
               break;
           }

           Console.Write("Press Enter to continue or type 'quit' to finish: ");
           string input = Console.ReadLine();

           if (input != null && input.Trim().ToLower() == "quit")
           {
               break;
           }

           // Hide 3 random unhidden words at a time
           currentScripture.HideRandomWords(3);
       }
   }
}