using System;
using System.Collections.Generic;
using System.Threading;

public abstract class ActivityBase
{
    protected string description;
    protected int duration;

    public ActivityBase(string description)
    {
        this.description = description;
    }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Activity: {this.description}");
        Console.Write("Enter the duration in seconds for this activity: ");
        this.duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin in 3 seconds...");
        DisplayCountdown(3);
    }

    protected void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public virtual void EndActivity()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {this.description} for {this.duration} seconds.");
        Thread.Sleep(2000);
    }

    public abstract void ExecuteActivity();
}

public class BreathingActivity : ActivityBase
{
    public BreathingActivity() : base("Breathing Activity")
    {
    }

    public override void ExecuteActivity()
    {
        StartActivity();
        DateTime endTime = DateTime.Now.AddSeconds(this.duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000);
        }
        EndActivity();
    }
}

public class ReflectionActivity : ActivityBase
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
    };

    public ReflectionActivity() : base("Reflection Activity")
    {
    }

    public override void ExecuteActivity()
    {
        StartActivity();
        Random rnd = new Random();
        Console.WriteLine(prompts[rnd.Next(prompts.Count)]);
        DateTime endTime = DateTime.Now.AddSeconds(this.duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(questions[rnd.Next(questions.Count)]);
            Thread.Sleep(5000);
        }
        EndActivity();
    }
}

public class ListingActivity : ActivityBase
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        // ... Add all other prompts here
    };

    public ListingActivity() : base("Listing Activity")
    {
    }

    public override void ExecuteActivity()
    {
        StartActivity();
        Random rnd = new Random();
        Console.WriteLine(prompts[rnd.Next(prompts.Count)]);
        DateTime endTime = DateTime.Now.AddSeconds(this.duration);
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Enter an item: ");
            string item = Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You have listed {count} items.");
        EndActivity();
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        int choice = int.Parse(Console.ReadLine());

        ActivityBase activity;
        switch (choice)
        {
            case 1:
                activity = new BreathingActivity();
                break;
            case 2:
                activity = new ReflectionActivity();
                break;
            case 3:
                activity = new ListingActivity();
                break;
            default:
                return;
        }

        activity.ExecuteActivity();
    }
}
