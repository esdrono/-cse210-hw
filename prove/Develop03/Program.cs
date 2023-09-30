// For exceeding requirements completed: Have your program work with a library of scriptures rather than a single one. Choose scriptures at random to present to the user.

using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemoryHelper
{
    public class ScriptureReference
    {
        public string BookName { get; private set; }
        public int Chapter { get; private set; }
        public int StartingVerse { get; private set; }
        public int? EndingVerse { get; private set; }

        public ScriptureReference(string bookName, int chapter, int verse)
        {
            BookName = bookName;
            Chapter = chapter;
            StartingVerse = verse;
            EndingVerse = null;
        }

        public ScriptureReference(string bookName, int chapter, int startingVerse, int endingVerse)
        {
            BookName = bookName;
            Chapter = chapter;
            StartingVerse = startingVerse;
            EndingVerse = endingVerse;
        }

        public override string ToString()
        {
            if (EndingVerse.HasValue)
                return $"{BookName} {Chapter}:{StartingVerse}-{EndingVerse.Value}";
            else
                return $"{BookName} {Chapter}:{StartingVerse}";
        }
    }

    public class ScriptureWord
    {
        public string Word { get; private set; }
        public bool IsHidden { get; set; }

        public ScriptureWord(string word)
        {
            Word = word;
            IsHidden = false;
        }

        public override string ToString()
        {
            return IsHidden ? "____" : Word;
        }
    }

    public class Scripture
    {
        public ScriptureReference Reference { get; private set; }
        public List<ScriptureWord> Words { get; private set; }

        public Scripture(ScriptureReference reference, string text)
        {
            Reference = reference;
            Words = text.Split(' ').Select(w => new ScriptureWord(w)).ToList();
        }

        public void HideRandomWords(int count)
        {
            var wordsToHide = Words.Where(w => !w.IsHidden).OrderBy(x => Guid.NewGuid()).Take(count).ToList();
            foreach (var word in wordsToHide)
            {
                word.IsHidden = true;
            }
        }

        public bool AreAllWordsHidden()
        {
            return Words.All(w => w.IsHidden);
        }

        public override string ToString()
        {
            return $"{Reference} {string.Join(" ", Words)}";
        }
    }

    public class ScriptureLibrary
    {
        private List<Scripture> Scriptures { get; set; }

        public ScriptureLibrary()
        {
            Scriptures = new List<Scripture>();
        }

        public void AddScripture(Scripture scripture)
        {
            Scriptures.Add(scripture);
        }

        public Scripture GetRandomScripture()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, Scriptures.Count);
            return Scriptures[randomIndex];
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ScriptureLibrary scriptureLibrary = new ScriptureLibrary();
            
            scriptureLibrary.AddScripture(new Scripture(new ScriptureReference("John", 3, 16), "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life."));
            scriptureLibrary.AddScripture(new Scripture(new ScriptureReference("Psalm", 23, 1), "The LORD is my shepherd; I shall not want."));
            scriptureLibrary.AddScripture(new Scripture(new ScriptureReference("Proverbs", 3, 5, 6), "Trust in the LORD with all your heart, and do not lean on your own understanding. In all your ways acknowledge him, and he will make straight your paths."));

            Scripture scripture = scriptureLibrary.GetRandomScripture();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture);
                Console.WriteLine("\nPress Enter to hide some words or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.Trim().ToLower() == "quit")
                    break;

                scripture.HideRandomWords(5);

                if (scripture.AreAllWordsHidden())
                {
                    Console.WriteLine("All words are hidden!");
                    break;
                }
            }
        }
    }
}
