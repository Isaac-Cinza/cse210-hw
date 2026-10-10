using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private const int PointsPerLevel = 500;

    private List<Goal> _goals = new List<Goal>();
    private int _score;

    private string[] _titles =
    {
        "Novice", "Apprentice", "Adventurer", "Hero", "Champion", "Legend"
    };

    public GoalManager()
    {
        _score = 0;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        int level = GetLevel();

        Console.WriteLine($"You have {_score} points. Level {level}: {GetTitle(level)}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            // Polymorphism: each goal builds its own details string.
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (bad habit)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        if (type != "1" && type != "2" && type != "3" && type != "4")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = CleanText(Console.ReadLine());

        Console.Write("What is a short description of it? ");
        string description = CleanText(Console.ReadLine());

        int points = AskForNumber("What is the amount of points associated with this goal? ", 1);

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            int target = AskForNumber("How many times does this goal need to be accomplished for a bonus? ", 1);
            int bonus = AskForNumber("What is the bonus for accomplishing it that many times? ", 0);

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            _goals.Add(new NegativeGoal(name, description, points));
        }

        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet. Create one first.");
            return;
        }

        ListGoalNames();
        int number = AskForNumber("Which goal did you accomplish? ", 1);

        if (number > _goals.Count)
        {
            Console.WriteLine("That goal does not exist.");
            return;
        }

        Goal goal = _goals[number - 1];
        int points = goal.RecordEvent();

        if (points > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {points} points!");
        }
        else if (points < 0)
        {
            Console.WriteLine($"Oh no! You lost {-points} points. Tomorrow is a new day!");
        }
        else
        {
            Console.WriteLine("This goal is already complete, so no points were earned.");
        }

        int oldLevel = GetLevel();
        _score = Math.Max(0, _score + points);
        int newLevel = GetLevel();

        if (newLevel > oldLevel)
        {
            Console.WriteLine($"*** LEVEL UP! You are now level {newLevel}: {GetTitle(newLevel)}! ***");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Saved {_goals.Count} goals to {file}.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        if (!File.Exists(file))
        {
            Console.WriteLine($"File '{file}' was not found.");
            return;
        }

        string[] lines = File.ReadAllLines(file);

        if (lines.Length == 0 || !int.TryParse(lines[0], out int loadedScore))
        {
            Console.WriteLine("This file is not a valid goal file.");
            return;
        }

        List<Goal> loadedGoals = new List<Goal>();

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = CreateGoalFromString(lines[i]);

            if (goal != null)
            {
                loadedGoals.Add(goal);
            }
        }

        // Replace the current goals only when the whole file was read.
        _score = loadedScore;
        _goals = loadedGoals;

        Console.WriteLine($"Loaded {_goals.Count} goals from {file}.");
    }

    // Private helper: builds the right type of goal from one saved line.
    private Goal CreateGoalFromString(string line)
    {
        string[] typeAndDetails = line.Split(':', 2);

        if (typeAndDetails.Length != 2)
        {
            return null;
        }

        string type = typeAndDetails[0];
        string[] parts = typeAndDetails[1].Split('|');

        try
        {
            if (type == "SimpleGoal" && parts.Length == 4)
            {
                return new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3]));
            }
            else if (type == "EternalGoal" && parts.Length == 3)
            {
                return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
            }
            else if (type == "ChecklistGoal" && parts.Length == 6)
            {
                return new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]),
                    int.Parse(parts[4]), int.Parse(parts[3]), int.Parse(parts[5]));
            }
            else if (type == "NegativeGoal" && parts.Length == 3)
            {
                return new NegativeGoal(parts[0], parts[1], int.Parse(parts[2]));
            }
        }
        catch (FormatException)
        {
            return null;
        }

        return null;
    }

    private int AskForNumber(string question, int minimum)
    {
        while (true)
        {
            Console.Write(question);

            if (int.TryParse(Console.ReadLine(), out int number) && number >= minimum)
            {
                return number;
            }

            Console.WriteLine($"Please enter a whole number of {minimum} or more.");
        }
    }

    // The saved file uses | and : as separators, so they are removed from the text.
    private string CleanText(string text)
    {
        return text.Replace("|", "/").Replace(":", "-");
    }

    private int GetLevel()
    {
        return _score / PointsPerLevel + 1;
    }

    private string GetTitle(int level)
    {
        int index = Math.Min(level - 1, _titles.Length - 1);

        return _titles[index];
    }
}
