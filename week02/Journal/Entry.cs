using System;
using System.Collections.Generic;
using System.Text;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }

    // Converts this entry into one CSV line. Every value is wrapped in quotes
    // and any quote inside the value is doubled, so commas and quotes are safe.
    public string ToCsvLine()
    {
        return $"{Escape(_date)},{Escape(_promptText)},{Escape(_entryText)}";
    }

    // Builds an Entry from one CSV line. Returns null if the line is invalid.
    public static Entry FromCsvLine(string line)
    {
        List<string> fields = SplitCsv(line);

        if (fields.Count != 3)
        {
            return null;
        }

        return new Entry(fields[0], fields[1], fields[2]);
    }

    private static string Escape(string value)
    {
        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }

    private static List<string> SplitCsv(string line)
    {
        List<string> fields = new List<string>();
        StringBuilder current = new StringBuilder();
        bool insideQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (insideQuotes)
            {
                if (c == '"' && i + 1 < line.Length && line[i + 1] == '"')
                {
                    current.Append('"');
                    i++;
                }
                else if (c == '"')
                {
                    insideQuotes = false;
                }
                else
                {
                    current.Append(c);
                }
            }
            else
            {
                if (c == '"')
                {
                    insideQuotes = true;
                }
                else if (c == ',')
                {
                    fields.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(c);
                }
            }
        }

        fields.Add(current.ToString());
        return fields;
    }
}