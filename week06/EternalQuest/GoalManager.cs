using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
   private List<Goal> _goals;
   private int _score;

   public GoalManager()
   {
       _goals = new List<Goal>();
       _score = 0;
   }

   public void Start()
   {
       int choice = 0;
       while (choice != 6)
       {
           DisplayPlayerInfo();
           Console.WriteLine("\nMenu Options:");
           Console.WriteLine("  1. Create New Goal");
           Console.WriteLine("  2. List Goals");
           Console.WriteLine("  3. Save Goals");
           Console.WriteLine("  4. Load Goals");
           Console.WriteLine("  5. Record Event");
           Console.WriteLine("  6. Quit");
           Console.Write("Select a choice from the menu: ");

           string input = Console.ReadLine();
           if (int.TryParse(input, out choice))
           {
               switch (choice)
               {
                   case 1:
                       CreateGoal();
                       break;
                   case 2:
                       ListGoalDetails();
                       break;
                   case 3:
                       SaveGoals();
                       break;
                   case 4:
                       LoadGoals();
                       break;
                   case 5:
                       RecordEvent();
                       break;
                   case 6:
                       Console.WriteLine("\nGoodbye! Keep up the good work on your goals.");
                       break;
                   default:
                       Console.WriteLine("\nInvalid choice. Please select between 1 and 6.");
                       break;
               }
           }
           else
           {
               Console.WriteLine("\nInvalid input. Please enter a valid number.");
           }
       }
   }

   private void DisplayPlayerInfo()
   {
       // =========================================================
       // EXCEEDING REQUIREMENTS: Dynamic Leveling & Rank Calculation
       // =========================================================
       int level = (_score / 1000) + 1;
       string rank = level switch
       {
           1 => "Novice Seeker",
           2 => "Dedicated Disciple",
           3 => "Pathfinder",
           4 => "Eternal Quest Champion",
           _ => "Master of the Eternal Path"
       };

       Console.WriteLine($"\n========================================");
       Console.WriteLine($" You have {_score} points.");
       Console.WriteLine($" Level {level}: {rank}");
       Console.WriteLine($"========================================");
   }

   private void ListGoalDetails()
   {
       Console.WriteLine("\nThe goals are:");
       for (int i = 0; i < _goals.Count; i++)
       {
           Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
       }
   }

   private void CreateGoal()
   {
       Console.WriteLine("\nThe types of Goals are:");
       Console.WriteLine("  1. Simple Goal");
       Console.WriteLine("  2. Eternal Goal");
       Console.WriteLine("  3. Checklist Goal");
       Console.Write("Which type of goal would you like to create? ");

       string typeInput = Console.ReadLine();
       if (int.TryParse(typeInput, out int goalType))
       {
           Console.Write("What is the name of your goal? ");
           string name = Console.ReadLine();
           Console.Write("What is a short description of it? ");
           string description = Console.ReadLine();
           Console.Write("What is the amount of points associated with this goal? ");

           if (int.TryParse(Console.ReadLine(), out int points))
           {
               Goal newGoal = null;

               if (goalType == 1)
               {
                   newGoal = new SimpleGoal(name, description, points);
               }
               else if (goalType == 2)
               {
                   newGoal = new EternalGoal(name, description, points);
               }
               else if (goalType == 3)
               {
                   Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                   int.TryParse(Console.ReadLine(), out int target);
                   Console.Write("What is the bonus for accomplishing it that many times? ");
                   int.TryParse(Console.ReadLine(), out int bonus);
                   newGoal = new ChecklistGoal(name, description, points, target, bonus);
               }

               if (newGoal != null)
               {
                   _goals.Add(newGoal);
                   Console.WriteLine("\nGoal created successfully!");
               }
               else
               {
                   Console.WriteLine("\nInvalid goal type choice.");
               }
           }
       }
   }

   private void RecordEvent()
   {
       ListGoalDetails();
       Console.Write("Which goal did you accomplish? ");
       if (int.TryParse(Console.ReadLine(), out int index))
       {
           int adjustedIndex = index - 1;
           if (adjustedIndex >= 0 && adjustedIndex < _goals.Count)
           {
               Goal goal = _goals[adjustedIndex];
               int earnedPoints = goal.RecordEvent();
               _score += earnedPoints;

               Console.WriteLine($"\nCongratulations! You have earned {earnedPoints} points!");
               Console.WriteLine($"You now have {_score} points.");
           }
           else
           {
               Console.WriteLine("\nInvalid goal number selection.");
           }
       }
   }

   private void SaveGoals()
   {
       Console.Write("What is the filename for the goal file? ");
       string filename = Console.ReadLine();

       using (StreamWriter outputFile = new StreamWriter(filename))
       {
           outputFile.WriteLine(_score);
           foreach (Goal goal in _goals)
           {
               outputFile.WriteLine(goal.GetStringRepresentation());
           }
       }
       Console.WriteLine("\nGoals saved successfully!");
   }

   private void LoadGoals()
   {
       Console.Write("What is the filename for the goal file? ");
       string filename = Console.ReadLine();

       if (File.Exists(filename))
       {
           string[] lines = File.ReadAllLines(filename);
           _score = int.Parse(lines[0]);
           _goals.Clear();

           for (int i = 1; i < lines.Length; i++)
           {
               string line = lines[i];
               string[] parts = line.Split(':');
               string goalType = parts[0];
               string[] details = parts[1].Split(',');

               if (goalType == "SimpleGoal")
               {
                   string name = details[0];
                   string description = details[1];
                   int points = int.Parse(details[2]);
                   bool isComplete = bool.Parse(details[3]);

                   _goals.Add(new SimpleGoal(name, description, points, isComplete));
               }
               else if (goalType == "EternalGoal")
               {
                   string name = details[0];
                   string description = details[1];
                   int points = int.Parse(details[2]);

                   _goals.Add(new EternalGoal(name, description, points));
               }
               else if (goalType == "ChecklistGoal")
               {
                   string name = details[0];
                   string description = details[1];
                   int points = int.Parse(details[2]);
                   int target = int.Parse(details[3]);
                   int bonus = int.Parse(details[4]);
                   int amountCompleted = int.Parse(details[5]);

                   _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
               }
           }
           Console.WriteLine("\nGoals loaded successfully!");
       }
       else
       {
           Console.WriteLine("\nFile not found.");
       }
   }
}