using System;
using System.Collections.Generic;

public class Scripture
{
   private Reference _reference;
   private List<Word> _words;

   public Scripture(Reference reference, string text)
   {
       _reference = reference;
       _words = new List<Word>();

       string[] wordArray = text.Split(' ');
       foreach (string item in wordArray)
       {
           _words.Add(new Word(item));
       }
   }

   public void HideRandomWords(int numberToHide)
   {
       List<Word> unhiddenWords = new List<Word>();
       foreach (Word word in _words)
       {
           if (!word.IsHidden())
           {
               unhiddenWords.Add(word);
           }
       }

       Random random = new Random();
       int countToHide = Math.Min(numberToHide, unhiddenWords.Count);

       for (int i = 0; i < countToHide; i++)
       {
           int index = random.Next(unhiddenWords.Count);
           unhiddenWords[index].Hide();
           unhiddenWords.RemoveAt(index);
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
       foreach (Word word in _words)
       {
           if (!word.IsHidden())
           {
               return false;
           }
       }
       return true;
   }
}