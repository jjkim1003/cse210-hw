using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        // Split up the words in text and store each as a Word object in the list _words
        _words = text.Split(' ') // Split by spaces to get individual words
                     .Select(word => new Word(word)) // Create a Word object for each word
                     .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        // Set the state of a randomly selected group of words to be hidden
        // Need to find a set of visible words
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        // Need to randomly select "numberToHide" of those words
        var random = new Random();
        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        // Combine the reference and words
        string referenceText = _reference.GetDisplayText();
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{referenceText}\n{scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        // Check if all words are hidden
        return _words.All(word => word.IsHidden());
    }
}