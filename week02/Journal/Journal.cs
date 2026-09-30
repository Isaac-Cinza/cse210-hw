using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine("Date,Prompt,Response");

            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToCsvLine());
            }
        }

        Console.WriteLine($"Journal saved to {file}.");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File '{file}' was not found.");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        List<Entry> loadedEntries = new List<Entry>();

        // Start at index 1 to skip the header line.
        for (int i = 1; i < lines.Length; i++)
        {
            Entry entry = Entry.FromCsvLine(lines[i]);

            if (entry != null)
            {
                loadedEntries.Add(entry);
            }
        }

        // Replace the current entries with the loaded ones.
        _entries = loadedEntries;
        Console.WriteLine($"Loaded {_entries.Count} entries from {file}.");
    }
}