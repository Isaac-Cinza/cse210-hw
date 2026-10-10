using System;
using System.Collections.Generic;
using System.IO;

// Keeps track of how many times, and how long, each activity was done.
public class ActivityLog
{
    private Dictionary<string, int> _counts = new Dictionary<string, int>();
    private Dictionary<string, int> _seconds = new Dictionary<string, int>();

    public void Record(string activityName, int seconds)
    {
        if (!_counts.ContainsKey(activityName))
        {
            _counts[activityName] = 0;
            _seconds[activityName] = 0;
        }

        _counts[activityName]++;
        _seconds[activityName] += seconds;
    }

    public void Display()
    {
        Console.WriteLine("Your mindfulness log:");
        Console.WriteLine();

        if (_counts.Count == 0)
        {
            Console.WriteLine("No activities recorded yet.");
            return;
        }

        foreach (string name in _counts.Keys)
        {
            Console.WriteLine($"{name}: {_counts[name]} time(s), {_seconds[name]} seconds in total");
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (string name in _counts.Keys)
            {
                outputFile.WriteLine($"{name}|{_counts[name]}|{_seconds[name]}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            return;
        }

        foreach (string line in File.ReadAllLines(file))
        {
            string[] parts = line.Split("|");

            if (parts.Length == 3
                && int.TryParse(parts[1], out int count)
                && int.TryParse(parts[2], out int seconds))
            {
                _counts[parts[0]] = count;
                _seconds[parts[0]] = seconds;
            }
        }
    }
}
