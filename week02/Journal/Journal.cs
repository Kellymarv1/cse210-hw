using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
   private List<Entry> _entries = new List<Entry>();
   private PromptGenerator _promptGenerator = new PromptGenerator();

   public void AddEntry()
   {
       string prompt = _promptGenerator.GetRandomPrompt();

       Console.WriteLine($"\n{prompt}");
       Console.Write("> ");
       string response = Console.ReadLine();

       string date = DateTime.Now.ToShortDateString();

       Entry newEntry = new Entry(date, prompt, response);
       _entries.Add(newEntry);
       Console.WriteLine("Entry added successfully!");
   }

   public void DisplayJournal()
   {
       if (_entries.Count == 0)
       {
           Console.WriteLine("\nYour journal is currently empty.");
           return;
       }

       Console.WriteLine("\n--- Journal Entries ---");
       foreach (Entry entry in _entries)
       {
           entry.Display();
       }
   }

   public void SaveToFile(string filename)
   {
       using (StreamWriter outputFile = new StreamWriter(filename))
       {
           foreach (Entry entry in _entries)
           {
               // Updated to access the new _camelCase member variables
               outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}");
           }
       }
       Console.WriteLine("Journal saved successfully.");
   }

   public void LoadFromFile(string filename)
   {
       if (!File.Exists(filename))
       {
           Console.WriteLine("File not found.");
           return;
       }

       _entries.Clear();
       string[] lines = File.ReadAllLines(filename);

       foreach (string line in lines)
       {
           string[] parts = line.Split("~|~");
           if (parts.Length == 3)
           {
               Entry entry = new Entry(parts[0], parts[1], parts[2]);
               _entries.Add(entry);
           }
       }
       Console.WriteLine("Journal loaded successfully.");
   }
}