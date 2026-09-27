using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("THE W02 EXERCISE 2 | About Variables and Conditional Statements");
        Console.WriteLine("---------------------------------------------------------------");
        
        Console.WriteLine("What is your grade percentage?"); 
        string answer = Console.ReadLine(); 
        int percent = int.Parse(answer);
        string LetterGrade = "";

        if (percent >= 90)
        {
            LetterGrade = "A";
        }
        else if (percent >= 80)
        {
            LetterGrade = "B";
        }
        else if (percent >= 70)
        {
            LetterGrade = "C";
        }
        else if (percent >= 60)
        {
            LetterGrade = "D";
        }
        else
        {
            LetterGrade = "F";
        }
        
        Console.WriteLine($"Your letter grade is: {LetterGrade}");

        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the class. Better luck next time!");
        }


    Console.WriteLine("--------Signed : Isaac CINZA----------");
    }
}
