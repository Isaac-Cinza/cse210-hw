using System;

// EXCEEDING REQUIREMENTS:
// 1. The journal is saved and loaded as a real .csv file (with a header row) that
//    opens correctly in Excel. Every value is wrapped in quotes and quotation marks
//    inside the text are doubled, so commas and quotes in an entry never break the file.
// 2. Loading is safe: it checks that the file exists, skips the header, ignores
//    malformed lines, and only replaces the current journal if the file was found.
// 3. The CSV logic lives inside the Entry class (ToCsvLine / FromCsvLine), so the
//    Journal class does not need to know how an entry is formatted (abstraction).
// 4. The menu handles invalid choices and the prompt list has 8 prompts.

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                choice = 0;
            }

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();
                Entry newEntry = new Entry(date, prompt, response);
                theJournal.AddEntry(newEntry);
            }
            else if (choice == 2)
            {
                theJournal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("What is the filename? ");
                string file = Console.ReadLine();
                theJournal.LoadFromFile(file);
            }
            else if (choice == 4)
            {
                Console.Write("What is the filename? ");
                string file = Console.ReadLine();
                theJournal.SaveToFile(file);
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
            }
        }
    }
}