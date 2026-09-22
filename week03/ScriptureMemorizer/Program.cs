using System;
using System.Collections.Generic;

class Program
{
   static void Main(string[] args)
   {
       Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

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

       Random random = new Random();
       Scripture currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

       while (true)
       {
           Console.Clear();
           Console.WriteLine(currentScripture.GetDisplayText());
           Console.WriteLine();

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

           currentScripture.HideRandomWords(3);
       }
   }
}