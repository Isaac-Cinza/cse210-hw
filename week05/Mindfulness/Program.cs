using System;

// EXCEEDING REQUIREMENTS:
// 1. No repeated prompts or questions: the NonRepeatingPicker class never gives the
//    same prompt/question again until all of them have been used once in the session.
// 2. Activity log: ActivityLog counts how many times, and how many seconds, each
//    activity was done. It is shown from the menu (option 4).
// 3. Saving and loading: the log is saved to mindfulness_log.txt after every activity
//    and loaded when the program starts, so your history is kept between sessions.
// 4. Better breathing animation: a bar of "=" grows slowly while you breathe in (4 s)
//    and shrinks while you breathe out (6 s), using backspaces.
// 5. Input check: the duration must be a whole number greater than 0.

class Program
{
    private const string LogFile = "mindfulness_log.txt";

    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog();
        log.LoadFromFile(LogFile);

        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity log");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                log.Record(breathing.GetName(), breathing.GetDuration());
                log.SaveToFile(LogFile);
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                log.Record(reflecting.GetName(), reflecting.GetDuration());
                log.SaveToFile(LogFile);
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                log.Record(listing.GetName(), listing.GetDuration());
                log.SaveToFile(LogFile);
            }
            else if (choice == "4")
            {
                Console.Clear();
                log.Display();
                Console.WriteLine();
                Console.Write("Press enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}
