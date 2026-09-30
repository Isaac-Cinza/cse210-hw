using System;

// EXCEEDING REQUIREMENTS:
// 1. Library of scriptures: the ScriptureLibrary class stores five scriptures
//    (including verse ranges) and the program picks one at random each run.
// 2. Smarter hiding: only words that are NOT hidden yet are chosen at random,
//    so every Enter always hides new words (the stretch challenge).
// 3. Punctuation is kept: only letters are replaced by underscores, so the
//    number of underscores still matches the number of letters in each word.
// 4. The user can type "quit" in any capitalization, and the program also ends
//    by itself when all words are hidden, showing the final hidden scripture.

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}