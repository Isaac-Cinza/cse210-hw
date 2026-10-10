using System;
using System.Collections.Generic;

// Picks random items but never repeats one until all have been used once.
public class NonRepeatingPicker
{
    private List<string> _items;
    private List<string> _remaining = new List<string>();
    private Random _random = new Random();

    public NonRepeatingPicker(List<string> items)
    {
        _items = items;
    }

    public string GetNext()
    {
        if (_remaining.Count == 0)
        {
            _remaining = new List<string>(_items);
        }

        int index = _random.Next(_remaining.Count);
        string item = _remaining[index];
        _remaining.RemoveAt(index);

        return item;
    }
}
