using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
   private Reference _reference;
   private List<Word> _words;

   public Scripture(Reference reference, string text)
   {
       _reference = reference;
       _words = new List<Word>();

       string[] wordArray = text.Split(' ');
       foreach (string word in wordArray)
       {
           _words.Add(new Word(word));
       }
   }

   public void HideRandomWords(int numberToHide)
   {
       // Stretch challenge: Select only from words that are not already hidden
       List<Word> unhiddenWords = _words.Where(w => !w.IsHidden()).ToList();
       
       Random random = new Random();
       int countToHide = Math.Min(numberToHide, unhiddenWords.Count);

       for (int i = 0; i < countToHide; i++)
       {
           int index = random.Next(unhiddenWords.Count);
           unhiddenWords[index].Hide();
           unhiddenWords.RemoveAt(index); // Remove from temporary list to prevent picking the same word twice in this batch
       }
   }

   public string GetDisplayText()
   {
       string displayText = _reference.GetDisplayText() + " ";
       foreach (Word word in _words)
       {
           displayText += word.GetDisplayText() + " ";
       }
       return displayText.TrimEnd();
   }

   public bool IsCompletelyHidden()
   {
       return _words.All(w => w.IsHidden());
   }
}