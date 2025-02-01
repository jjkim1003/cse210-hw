using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create sample videos
        Video video1 = new Video("C# Basics", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I learned a lot!"));
        videos.Add(video1);

        Video video2 = new Video("Advanced C#", "Jane Smith", 1200);
        video2.AddComment(new Comment("David", "This was amazing!"));
        video2.AddComment(new Comment("Eve", "Really clear explanations."));
        video2.AddComment(new Comment("Frank", "Best tutorial ever!"));
        videos.Add(video2);

        Video video3 = new Video("C# Design Patterns", "Chris Johnson", 900);
        video3.AddComment(new Comment("Grace", "Very informative."));
        video3.AddComment(new Comment("Hank", "Loved the examples."));
        video3.AddComment(new Comment("Ivy", "Super helpful for my project!"));
        videos.Add(video3);

        // Iterate through the list and display video information
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
