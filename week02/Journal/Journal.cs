using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine(); // Add a blank line between entries
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry._date);
                writer.WriteLine(entry._promptText);
                writer.WriteLine(entry._entryText);
                writer.WriteLine("-----"); // Separator for entries
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        _entries.Clear();

        using (StreamReader reader = new StreamReader(file))
        {
            while (!reader.EndOfStream)
            {
                string date = reader.ReadLine();
                string prompt = reader.ReadLine();
                string entryText = reader.ReadLine();
                string separator = reader.ReadLine(); // Read separator line (e.g., "-----")

                Entry entry = new Entry
                {
                    _date = date,
                    _promptText = prompt,
                    _entryText = entryText
                };

                _entries.Add(entry);
            }
        }

        Console.WriteLine("Journal loaded successfully.");
    }
}
