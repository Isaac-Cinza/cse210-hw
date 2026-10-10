using System;

// EXCEEDING REQUIREMENTS:
// 1. Levels and titles: every 500 points the player levels up (Novice, Apprentice,
//    Adventurer, Hero, Champion, Legend) and a "LEVEL UP!" message is shown.
// 2. A fourth kind of goal: NegativeGoal for bad habits. Recording it costs points
//    (the score never goes below 0). It is a new derived class of Goal that overrides
//    RecordEvent, IsComplete, GetDetailsString and GetStringRepresentation.
// 3. Safe input and loading: numbers are validated, text is cleaned so it cannot break
//    the save file, and a bad or missing file never erases the current goals.
// 4. Simple and checklist goals that are already complete do not give points again.

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}
