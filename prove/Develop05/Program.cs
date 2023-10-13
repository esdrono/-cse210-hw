using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // Base Class
    public abstract class Goal
    {
        public string Name { get; set; }
        public int PointsPerCompletion { get; set; }

        public abstract int RecordCompletion();
    }

    // Derived Classes
    public class SimpleGoal : Goal
    {
        public override int RecordCompletion()
        {
            // Simplified logic
            return PointsPerCompletion;
        }
    }

    public class EternalGoal : Goal
    {
        public override int RecordCompletion()
        {
            // Simplified logic
            return PointsPerCompletion;
        }
    }

    public class ChecklistGoal : Goal
    {
        public int CompletionTarget { get; set; }
        public int CurrentCompletion { get; set; }

        public override int RecordCompletion()
        {
            // Simplified logic
            CurrentCompletion++;
            if (CurrentCompletion == CompletionTarget)
            {
                return PointsPerCompletion * 2;  // Bonus points
            }
            return PointsPerCompletion;
        }
    }

    public class Program
    {
        private static List<Goal> goals = new List<Goal>();
        private static int userScore = 0;

        public static void Main(string[] args)
        {
            // Example of creating goals
            goals.Add(new SimpleGoal { Name = "Run a Marathon", PointsPerCompletion = 1000 });
            goals.Add(new EternalGoal { Name = "Read Scriptures", PointsPerCompletion = 100 });
            goals.Add(new ChecklistGoal { Name = "Attend Temple", PointsPerCompletion = 50, CompletionTarget = 10 });

            // Simplified UI
            while (true)
            {
                Console.WriteLine("1. Record Goal Completion\n2. View Goals\n3. Exit");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RecordGoalCompletion();
                        break;
                    case "2":
                        ViewGoals();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        public static void RecordGoalCompletion()
        {
            Console.WriteLine("Enter goal name:");
            var goalName = Console.ReadLine();
            var goal = goals.Find(g => g.Name == goalName);
            if (goal != null)
            {
                userScore += goal.RecordCompletion();
                Console.WriteLine($"Goal recorded. Your score: {userScore}");
            }
            else
            {
                Console.WriteLine("Goal not found.");
            }
        }

        public static void ViewGoals()
        {
            foreach (var goal in goals)
            {
                Console.WriteLine($"{goal.Name} - {goal.PointsPerCompletion} points per completion");
            }
        }
    }
}
