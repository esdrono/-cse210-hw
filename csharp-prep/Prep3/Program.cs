using System;

class Program
{
    static void Main()
    {
        // Step 1: Ask the user for the magic number (randomly generated in the final step)
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        int guess;

        // Step 2: Add a loop that continues until the user guesses the magic number
        do
        {
            // Step 3: Ask the user for their guess
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // Step 4: Use an if statement to provide feedback on the guess
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
        while (guess != magicNumber);

        // Step 5: Generate a random magic number from 1 to 100
        Random random = new Random();
        magicNumber = random.Next(1, 101);

        // Re-run the game with a random magic number
        Console.WriteLine("\nLet's play again with a new magic number!");
        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
        while (guess != magicNumber);
    }
}
using System;

class Program
{
    static void Main()
    {
        // Step 1: Ask the user for the magic number (randomly generated in the final step)
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        int guess;

        // Step 2: Add a loop that continues until the user guesses the magic number
        do
        {
            // Step 3: Ask the user for their guess
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // Step 4: Use an if statement to provide feedback on the guess
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
        while (guess != magicNumber);

        // Step 5: Generate a random magic number from 1 to 100
        Random random = new Random();
        magicNumber = random.Next(1, 101);

        // Re-run the game with a random magic number
        Console.WriteLine("\nLet's play again with a new magic number!");
        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
        while (guess != magicNumber);
    }
}
