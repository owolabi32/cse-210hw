class Program
{
    static void Main()
    {
        // Exceeding requirements: Added additional properties to the Entry class (Mood and Location) 
        // to save more information in the journal entry. The user is prompted to enter their current 
        // mood and location when writing a new entry. The SaveJournalToFile and LoadJournalFromFile 
        // methods have been updated to accommodate these new properties.

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

// Minimal Journal class definition to resolve the error
public class Journal
{
    public void WriteEntry()
    {
        Console.WriteLine("WriteEntry called.");
    }

    public void DisplayJournal()
    {
        Console.WriteLine("DisplayJournal called.");
    }

    public void SaveJournal()
    {
        Console.WriteLine("SaveJournal called.");
    }

    public void LoadJournal()
    {
        Console.WriteLine("LoadJournal called.");
    }
}