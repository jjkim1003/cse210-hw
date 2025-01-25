//for exceeding requirement, I added a lits of scriptures (currently 8). It chooses a verse randomly to help memorize it.
//I can add more scripture verses such as seminary 100 mastery verses.   
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Create a library of scriptures
        Dictionary<string, string> scriptureLibrary = new Dictionary<string, string>
        {
            { "John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life." },
            { "Proverbs 3:5-6", "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths." },
            { "Mosiah 2:17", "When ye are in the service of your fellow beings ye are only in the service of your God." },
            { "Alma 37:6-7", "By small and simple things are great things brought to pass; and small means in many instances doth confound the wise." },
            { "1 Nephi 3:7", "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."},
            { "2 Nephi 2:25", "Adam fell that men might be; and men are, that they might have joy." },
            { "2 Nephi 2:27", "Wherefore, men are free according to the flesh; and all things are given them which are expedient unto man. And they are free to choose liberty and eternal life, through the great Mediator of all men, or to choose captivity and death, according to the captivity and power of the devil; for he seeketh that all men might be miserable like unto himself."},
            { "2 Nephi 9:28-29", "O that cunning plan of the evil one! O the vainness, and the frailties, and the foolishness of men! When they are learned they think they are wise, and they hearken not unto the counsel of God, for they set it aside, supposing they know of themselves, wherefore, their wisdom is foolishness and it profiteth them not. And they shall perish. But to be learned is good if they hearken unto the counsels of God."}
        };
        

        // Step 2: Randomly select a scripture
        Random random = new Random();
        List<string> keys = new List<string>(scriptureLibrary.Keys);
        string randomReference = keys[random.Next(keys.Count)];
        string randomText = scriptureLibrary[randomReference];

        // Step 3: Parse the reference and create the Reference object
        Reference reference = ParseReference(randomReference);

        // Step 4: Create a Scripture object
        Scripture scripture = new Scripture(reference, randomText);

        // Step 5: Main program loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Program ending.");
                break;
            }

            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3); // Hide 3 random words per iteration
        }
    }

    // Method to parse a scripture reference string (e.g., "2 Nephi 2:25" or "Proverbs 3:5-6")
    static Reference ParseReference(string referenceString)
    {
        int colonIndex = referenceString.LastIndexOf(':'); // Find the last ':' in the string
        int spaceIndex = referenceString.LastIndexOf(' ', colonIndex); // Find the last space before the ':'

        // Extract book name, chapter, and verses
        string book = referenceString.Substring(0, spaceIndex); // Everything before the last space
        string chapterAndVerses = referenceString.Substring(spaceIndex + 1); // Everything after the last space

        if (chapterAndVerses.Contains('-')) // Multi-verse reference
        {
            string[] range = chapterAndVerses.Split(new[] { ':', '-' });
            int chapter = int.Parse(range[0]);
            int startVerse = int.Parse(range[1]);
            int endVerse = int.Parse(range[2]);
            return new Reference(book, chapter, startVerse, endVerse);
        }
        else // Single verse reference
        {
            string[] chapterVerse = chapterAndVerses.Split(':');
            int chapter = int.Parse(chapterVerse[0]);
            int verse = int.Parse(chapterVerse[1]);
            return new Reference(book, chapter, verse);
        }
    }
}
