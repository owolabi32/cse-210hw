using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Mood { get; set; }
    public string Location { get; set; }

    public Entry(string prompt, string response, string date, string mood, string location)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Mood = mood;
        Location = location;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nLocation: {Location}\nMood: {Mood}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

public class Journal
{
    public List<Entry> Entries { get; private set; }
    private List<string> Prompts { get; set; }
    private Random random;

    public Journal()
    {
        Entries = new List<Entry>();
        Prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What did I learn today?",
            "What am I grateful for today?"
        };
        random = new Random();
    }

    public void WriteEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        Console.Write("Enter your current mood: ");
        string mood = Console.ReadLine();
        Console.Write("Enter your current location: ");
        string location = Console.ReadLine();
        Entry entry = new Entry(prompt, response, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), mood, location);
        Entries.Add(entry);
    }

    private string GetRandomPrompt()
    {
        return Prompts[random.Next(Prompts.Count)];
    }

    public void DisplayJournal()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveJournal()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        SaveJournalToFile(Entries, filename);
    }

    public void LoadJournal()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        Entries = LoadJournalFromFile(filename);
    }

    private void SaveJournalToFile(List<Entry> entries, string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Location}|{entry.Mood}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    private List<Entry> LoadJournalFromFile(string filename)
    {
        List<Entry> entries = new List<Entry>();
        string[] lines = File.ReadAllLines(filename);

        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 5)
            {
                Entry entry = new Entry(parts[3], parts[4], parts[0], parts[2], parts[1]);
                entries.Add(entry);
            }
        }

        return entries;
    }
}

class Program
{
    // Exceeding requirements: Added additional properties to the Entry class (Mood and Location) 
    // to save more information in the journal entry. The user is prompted to enter their current 
    // mood and location when writing a new entry. The SaveJournalToFile and LoadJournalFromFile 
    // methods have been updated to accommodate these new properties.

    static void Main()
    {
        Journal journal = new Journal();
        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Quit");

            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournal();
                    break;
                case "4":
                    journal.LoadJournal();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }
}