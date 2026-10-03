using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learn C# in 10 Minutes", "CodeWithAmina", 600);
        video1.AddComment(new Comment("Jean", "Very clear explanation, thank you!"));
        video1.AddComment(new Comment("Grace", "I finally understand classes."));
        video1.AddComment(new Comment("Patrick", "Please make a video about lists."));
        videos.Add(video1);

        Video video2 = new Video("Best Coffee in Mbujimayi", "Daily Vlog Kasai", 345);
        video2.AddComment(new Comment("Esther", "Great place, I go there every week."));
        video2.AddComment(new Comment("David", "The video quality is excellent."));
        video2.AddComment(new Comment("Ruth", "Which street is it on?"));
        video2.AddComment(new Comment("Samuel", "Subscribed!"));
        videos.Add(video2);

        Video video3 = new Video("How to Study Medicine Effectively", "MedStudent Tips", 920);
        video3.AddComment(new Comment("Marie", "These tips helped me before my exams."));
        video3.AddComment(new Comment("Joseph", "Active recall really works."));
        video3.AddComment(new Comment("Naomi", "Thanks for sharing your schedule."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}
