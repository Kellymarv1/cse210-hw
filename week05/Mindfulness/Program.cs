using System;

// EXCEEDING REQUIREMENTS NOTE:
// To show creativity and exceed the core requirements, this program keeps track 
// of how many times each activity (Breathing, Reflection, and Listing) has been 
// performed during the current session. It displays a live session summary right 
// on the main menu so the user can track their mindfulness progress.

class Program
{
   static void Main(string[] args)
   {
       Console.WriteLine("Hello World! This is the Mindfulness Project.");

       int breathingCount = 0;
       int reflectionCount = 0;
       int listingCount = 0;

       string choice = "";
       while (choice != "4")
       {
           Console.Clear();
           Console.WriteLine("Menu Options:");
           Console.WriteLine("  1. Start breathing activity");
           Console.WriteLine("  2. Start reflection activity");
           Console.WriteLine("  3. Start listing activity");
           Console.WriteLine("  4. Quit");
           Console.WriteLine();
           
           Console.WriteLine($"[Session Summary — Breathing: {breathingCount} | Reflection: {reflectionCount} | Listing: {listingCount}]");
           Console.WriteLine();
           
           Console.Write("Select a choice from the menu: ");
           choice = Console.ReadLine();

           if (choice == "1")
           {
               BreathingActivity breathingActivity = new BreathingActivity();
               breathingActivity.Run();
               breathingCount++;
           }
           else if (choice == "2")
           {
               ReflectionActivity reflectionActivity = new ReflectionActivity();
               reflectionActivity.Run();
               reflectionCount++;
           }
           else if (choice == "3")
           {
               ListingActivity listingActivity = new ListingActivity();
               listingActivity.Run();
               listingCount++;
           }
           else if (choice == "4")
           {
               Console.WriteLine("\nThank you for using the Mindfulness Program. Have a wonderful day!");
           }
           else
           {
               Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 4.");
               System.Threading.Thread.Sleep(1500);
           }
       }
   }
}