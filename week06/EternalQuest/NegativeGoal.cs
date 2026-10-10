using System;

// A "bad habit" goal: recording it costs the player points.
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return -GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[!] {GetShortName()} ({GetDescription()}) -- costs {GetPoints()} points";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{GetBaseDetails()}";
    }
}
