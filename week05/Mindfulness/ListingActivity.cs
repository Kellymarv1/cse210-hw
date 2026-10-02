using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
   private List<string> _prompts = new List<string>
   {
       "Who are people that you appreciate?",
       "What are personal strengths of yours?",
       "Who are people that you have helped this week?",
       "When have you felt the Holy Ghost this month?",
       "Who are some of your personal heroes?"
   };

   public ListingActivity() : base("Listing Activity", 
       "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
   {
   }

   public void Run()
   {
       DisplayStartingMessage();
       DisplayRandomPrompt();

       Console.Write("You may begin in: ");
       ShowCountDown(5);
       Console.WriteLine();

       List<string> userItems = GetListFromUser();
       
       Console.WriteLine($"\nYou listed {userItems.Count} items!");
       DisplayEndingMessage();
   }

   private void DisplayRandomPrompt()
   {
       Random random = new Random();
       int index = random.Next(_prompts.Count);
       
       Console.WriteLine("\nList as many responses you can to the following prompt:\n");
       Console.WriteLine($" --- {_prompts[index]} ---\n");
   }

   private List<string> GetListFromUser()
   {
       List<string> items = new List<string>();
       DateTime startTime = DateTime.Now;
       DateTime endTime = startTime.AddSeconds(_duration);

       while (DateTime.Now < endTime)
       {
           if (DateTime.Now >= endTime) break;

           Console.Write("> ");
           string item = Console.ReadLine();
           
           if (!string.IsNullOrWhiteSpace(item))
           {
               items.Add(item);
           }
       }

       return items;
   }
}