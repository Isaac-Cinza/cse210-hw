using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    // A new simple goal always starts incomplete.
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    // Used when loading a saved goal.
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;

        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GetBaseDetails()}|{_isComplete}";
    }
}
