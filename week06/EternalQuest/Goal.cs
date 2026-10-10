using System;

// Base class: everything shared by all kinds of goals lives here.
public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // Each kind of goal records an event in its own way.
    // It returns the points earned (or lost) by this event.
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public abstract string GetStringRepresentation();

    // Default display. Only ChecklistGoal and NegativeGoal need a different one.
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";

        return $"{checkbox} {_shortName} ({_description})";
    }

    // Shared part of the saved text, so the children do not repeat it.
    protected string GetBaseDetails()
    {
        return $"{_shortName}|{_description}|{_points}";
    }
}
