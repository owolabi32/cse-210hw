using System;
using System.Collections.Generic;

public class Reference
{
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int StartVerse { get; set; }
    public int? EndVerse { get; set; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndVerse.HasValue)
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
    }
}

public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public string GetDisplayText()
    {
        if (IsHidden)
        {
            return new string('_', Text.Length);
        }
        else
        {
            return Text;
        }
    }

    public void Hide()
    {
        IsHidden = true;
    }
}

public class Scripture
{
    public Reference Reference { get; private set; }
    public List<Word> Words { get; private set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = new List<Word>();

        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            Words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.WriteLine($"{Reference} - {GetDisplayText()}");
    }

    public string GetDisplayText()
    {
        string displayText = "";
        foreach (Word word in Words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            int index = random.Next(Words.Count);
            if (!Words[index].IsHidden)
            {
                Words[index].Hide();
            }
            else
            {
                i--; // try again if the word is already hidden
            }
        }
    }

    public bool AreAllWordsHidden()
    {
        foreach (Word word in Words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only begotten Son that whoever believes in him shall not perish but have eternal life");

        while (true)
        {
            Console.Clear();
            scripture.Display();
            Console.Write("Press enter to hide words or type 'quit' to exit: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
            if (scripture.AreAllWordsHidden())
            {
                Console.Clear();
                scripture.Display();
                break;
            }
        }
    }
}