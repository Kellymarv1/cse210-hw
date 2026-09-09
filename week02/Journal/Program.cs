using System;

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Hello World! This is the Journal Project.");
       Journal journal = new Journal();
       int choice = 0;

       while (choice != 5)
       {
           Console.WriteLine("\nMenu:");
           Console.WriteLine("1. Write a new entry");
           Console.WriteLine("2. Display the journal");
           Console.WriteLine("3. Save the journal to a file");
           Console.WriteLine("4. Load the journal from a file");
           Console.WriteLine("5. Quit");
           Console.Write("Select an option from the menu: ");

           string input = Console.ReadLine();
           if (int.TryParse(input, out choice))
           {
               switch (choice)
               {
                   case 1:
                       journal.AddEntry();
                       break;
                   case 2:
                       journal.DisplayJournal();
                       break;
                   case 3:
                       Console.Write("What is the filename? ");
                       string saveFile = Console.ReadLine();
                       journal.SaveToFile(saveFile);
                       break;
                   case 4:
                       Console.Write("What is the filename? ");
                       string loadFile = Console.ReadLine();
                       journal.LoadFromFile(loadFile);
                       break;
                   case 5:
                       Console.WriteLine("Goodbye!");
                       break;
                   default:
                       Console.WriteLine("Invalid choice. Please select a number between 1 and 5.");
                       break;
               }
           }
           else
           {
               Console.WriteLine("Invalid input. Please enter a number.");
           }
       }
   }
}