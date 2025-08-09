Here's an updated version of the code with the additional features:
using System;
using System.Collections.Generic;
using System.IO;

public abstract class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void Start()
    {
        Console.WriteLine($"Welcome to the {name} Activity.");
        Console.WriteLine(description);
        Console.Write("How long would you like to do this activity for in seconds? ");
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void End()
    {
        Console.WriteLine("You have done a good job!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed the {name} Activity for {duration} seconds.");
        ShowSpinner(3);
        LogActivity();
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("-");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("\\");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("|");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(1000);
        }
    }

    protected void LogActivity()
    {
        string logEntry = $"{DateTime.Now} - {name} Activity completed for {duration} seconds.{Environment.NewLine}";
        File.AppendAllText("activity_log.txt", logEntry);
    }

    public abstract void Run();
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    public override void Run()
    {
        Start();
        int halfDuration = duration / 2;
        for (int i = 0; i < duration; i += 2)
        {
            Console.WriteLine("Breathe in...");
            for (int j = halfDuration; j > 0; j--)
            {
                Console.Write(new string('*', j));
                System.Threading.Thread.Sleep(100);
                Console.Write("\r");
            }
            Console.WriteLine();
            Console.WriteLine("Breathe out...");
            for (int j = halfDuration; j > 0; j--)
            {
                Console.Write(new string('*', j));
                System.Threading.Thread.Sleep(100);
                Console.Write("\r");
            }
            Console.WriteLine();
        }
        End();
    }
}

public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string> { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };
    private List<string> questions = new List<string> { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

    public override void Run()
    {
        Start();
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string question = questions[random.Next(questions.Count)];
            Console.WriteLine(question);
            ShowSpinner(5);
        }
        End();
    }
}

public class ListingActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    public override void Run()
    {
        Start();
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("You have a few seconds to think about your answer...");
        ShowSpinner(3);
        Console.WriteLine("Start listing items (press Enter after each, blank line to finish):");
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int count = 0;
        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                break;
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
        End();
    }
}