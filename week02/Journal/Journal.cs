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
            // Write a header row for the CSV file
            writer.WriteLine("Date,Prompt,Entry");

            foreach (Entry entry in _entries)
            {
                // Escape commas in user input to avoid breaking CSV format
                string sanitizedPrompt = entry._promptText.Replace(",", " ");
                string sanitizedEntry = entry._entryText.Replace(",", " ");

                writer.WriteLine($"{entry._date},{sanitizedPrompt},{sanitizedEntry}");
            }
        }
        Console.WriteLine("Journal saved successfully as a .csv file.");
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
            // Skip the header row
            string header = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');

                if (parts.Length == 3)
                {
                    Entry entry = new Entry
                    {
                        _date = parts[0],
                        _promptText = parts[1],
                        _entryText = parts[2]
                    };

                    _entries.Add(entry);
                }
            }
        }

        Console.WriteLine("Journal loaded successfully from the .csv file.");
    }
}
