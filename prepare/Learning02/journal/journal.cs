using System;
using System.Collections.Generic;

namespace DailyJournal
{
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
}
