using System;
using System.Threading;

// Base class: holds everything shared by all mindfulness activities.
public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = AskForDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[index % frames.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index++;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int number = seconds; number > 0; number--)
        {
            string text = number.ToString();
            Console.Write(text);
            Thread.Sleep(1000);

            // Move left, overwrite with spaces, move left again.
            Console.Write(new string('\b', text.Length));
            Console.Write(new string(' ', text.Length));
            Console.Write(new string('\b', text.Length));
        }
    }

    // Protected: only this class and its children need the end time.
    protected DateTime GetEndTime()
    {
        return DateTime.Now.AddSeconds(_duration);
    }

    private int AskForDuration()
    {
        int duration = 0;

        while (duration <= 0)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out duration) || duration <= 0)
            {
                Console.WriteLine("Please enter a whole number greater than 0.");
                duration = 0;
            }
        }

        return duration;
    }
}
