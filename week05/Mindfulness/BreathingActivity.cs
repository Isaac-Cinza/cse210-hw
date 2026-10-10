using System;
using System.Threading;

public class BreathingActivity : Activity
{
    private const int BarWidth = 20;

    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = GetEndTime();

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...  ");
            GrowBar(4);
            Console.WriteLine();

            Console.Write("Breathe out... ");
            ShrinkBar(6);
            Console.WriteLine();
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    // The bar grows while the user breathes in.
    private void GrowBar(int seconds)
    {
        int pause = seconds * 1000 / BarWidth;

        for (int i = 0; i < BarWidth; i++)
        {
            Console.Write("=");
            Thread.Sleep(pause);
        }
    }

    // The bar shrinks while the user breathes out.
    private void ShrinkBar(int seconds)
    {
        int pause = seconds * 1000 / BarWidth;

        Console.Write(new string('=', BarWidth));

        for (int i = 0; i < BarWidth; i++)
        {
            Thread.Sleep(pause);
            Console.Write("\b \b");
        }
    }
}
