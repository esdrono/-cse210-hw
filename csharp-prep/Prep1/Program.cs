using System;

class Program
{
    static void Main()
    {
        // Prompt for the first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompt for the last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display the formatted name
        string formattedName = $"Your name is {lastName}, {firstName} {lastName}.";
        Console.WriteLine(formattedName);
    }
}
