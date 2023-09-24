using System;
using System.Collections.Generic;
using System.IO;

namespace DailyJournal
{
    public class Entry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }
    }

    public class Journal
    {
        public List<Entry> Entries { get; set; } = new List<Entry>();

        public void AddEntry(Entry entry)
        {
            Entries.Add(entry);
        }

        public void DisplayEntries()
        {
            foreach (var entry in Entries)
            {
                Console.WriteLine($"Date: {entry.Date}, Prompt: {entry.Prompt}, Response: {entry.Response}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal myJournal = new Journal();
            string[] prompts = {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            string option = "";
            while (option != "5")
            {
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save to a file");
                Console.WriteLine("4. Load from a file");
                Console.WriteLine("5. Exit");

                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        WriteEntry(myJournal, prompts);
                        break;
                    case "2":
                        myJournal.DisplayEntries();
                        break;
                    case "3":
                        SaveToFile(myJournal);
                        break;
                    case "4":
                        LoadFromFile(myJournal);
                        break;
                }
            }
        }

        static void WriteEntry(Journal journal, string[] prompts)
        {
            Random rnd = new Random();
            int promptIndex = rnd.Next(0, prompts.Length);
            Console.WriteLine(prompts[promptIndex]);
            string response = Console.ReadLine();
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            Entry newEntry = new Entry(date, prompts[promptIndex], response);
            journal.AddEntry(newEntry);
        }

        static void SaveToFile(Journal journal)
        {
            Console.WriteLine("Enter filename:");
            string filename = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in journal.Entries)
                {
                    writer.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}");
                }
            }
        }

        static void LoadFromFile(Journal journal)
        {
            Console.WriteLine("Enter filename:");
            string filename = Console.ReadLine();
            journal.Entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split("~|~");
                    journal.AddEntry(new Entry(parts[0], parts[1], parts[2]));
                }
            }
        }
    }
}
