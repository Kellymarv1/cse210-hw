using System;

public class Entry
{
   // Member variables updated to use _camelCase with leading underscores
   public string _date;
   public string _promptText;
   public string _entryText;

   public Entry(string date, string promptText, string entryText)
   {
       _date = date;
       _promptText = promptText;
       _entryText = entryText;
   }

   public void Display()
   {
       Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
       Console.WriteLine($"{_entryText}\n");
   }
}