using System;
using System.Collections.Generic;

class Program
{
   static void Main(string[] args)
   {
       Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
       List<Video> videos = new List<Video>();

       Video video1 = new Video("C# Basics for Beginners", "Code With Tim", 640);
       video1.AddComment(new Comment("Alex", "Really clear explanation, thanks!"));
       video1.AddComment(new Comment("Sarah", "This helped me a lot with my homework."));
       video1.AddComment(new Comment("Mike", "Subscribed!"));
       videos.Add(video1);

       Video video2 = new Video("Building a Simple Game in Unity", "DevQuest", 1250);
       video2.AddComment(new Comment("Jessica", "Awesome tutorial! Part 2 please?"));
       video2.AddComment(new Comment("David", "Had a small bug but figured it out thanks to this video."));
       video2.AddComment(new Comment("Chloe", "Super clean code structure."));
       videos.Add(video2);

       Video video3 = new Video("Understanding OOP Abstraction", "Tech Academy", 480);
       video3.AddComment(new Comment("Ryan", "Abstraction finally clicks for me now."));
       video3.AddComment(new Comment("Emma", "Short and straight to the point. Perfect."));
       video3.AddComment(new Comment("Liam", "Thanks for making this video!"));
       videos.Add(video3);

       Video video4 = new Video("Top 5 VS Code Shortcuts", "Coding Shortcuts", 310);
       video4.AddComment(new Comment("Olivia", "Shortcut #3 is a lifesaver."));
       video4.AddComment(new Comment("Ethan", "Didn't know about that multi-cursor trick!"));
       video4.AddComment(new Comment("Zack", "Great video as always bro."));
       videos.Add(video4);

       foreach (Video v in videos)
       {
           Console.WriteLine($"Title: {v.GetTitle()}");
           Console.WriteLine($"Author: {v.GetAuthor()}");
           Console.WriteLine($"Length: {v.GetLength()} seconds");
           Console.WriteLine($"Comments ({v.GetNumberOfComments()}):");

           foreach (Comment c in v.GetComments())
           {
               Console.WriteLine($"  - {c.GetCommenterName()}: \"{c.GetText()}\"");
           }

           Console.WriteLine();
           Console.WriteLine("--------------------------------------------------");
           Console.WriteLine();
       }
   }
}