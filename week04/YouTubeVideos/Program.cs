using System;
using System.Collections.Generic;

// Define the Comment class
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}

// Define the Video class
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public override string ToString()
    {
        return $"{Title} by {Author}, Length: {Length} seconds";
    }
}

class Program
{
    static void Main()
    {
        // Create videos
        Video video1 = new Video("Video 1", "Author 1", 300);
        video1.AddComment(new Comment("John", "Great video!"));
        video1.AddComment(new Comment("Alice", "I loved it!"));
        video1.AddComment(new Comment("Bob", "Well done!"));

        Video video2 = new Video("Video 2", "Author 2", 240);
        video2.AddComment(new Comment("Mike", "Nice content!"));
        video2.AddComment(new Comment("Emma", "Keep it up!"));
        video2.AddComment(new Comment("David", "Good job!"));

        Video video3 = new Video("Video 3", "Author 3", 180);
        video3.AddComment(new Comment("Sophia", "Interesting!"));
        video3.AddComment(new Comment("Oliver", "Well explained!"));
        video3.AddComment(new Comment("Ava", "I learned something new!"));

        Video video4 = new Video("Video 4", "Author 4", 420);
        video4.AddComment(new Comment("Jackson", "Love it!"));
        video4.AddComment(new Comment("Isabella", "Great work!"));
        video4.AddComment(new Comment("Ethan", "Keep going!"));

        // Add videos to a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display video information
        foreach (Video video in videos)
        {
            Console.WriteLine(video.ToString());
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine(comment.ToString());
            }
            Console.WriteLine();
        }
    }
}