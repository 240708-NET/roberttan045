using System;
using System.Collections.Generic;
using System.Linq;
using WordScrambleGame.Models;
using WordScrambleGame.Repositories;

namespace WordScrambleGame.Services
{
    public class ScrambleManager
{
    private IWordRepository _wordRepository;
    private Dictionary<string, List<string>> usedWordsByDifficulty; // Track used words by difficulty

    public ScrambleManager(IWordRepository wordRepository)
    {
        _wordRepository = wordRepository;
        usedWordsByDifficulty = new Dictionary<string, List<string>>
        {
            { "1", new List<string>() }, // Easy
            { "2", new List<string>() }, // Medium
            { "3", new List<string>() }  // Hard
        };
    }

    public string GetScrambledWord(string difficulty)
    {
        var words = _wordRepository.GetWordsByDifficulty(difficulty);

        // Filter out used words
        var unusedWords = words.Where(w => !usedWordsByDifficulty[difficulty].Contains(w)).ToList();

        if (unusedWords.Count == 0)
        {
            return null; // No more words available for this difficulty
        }

        // Select a random unused word
        Random random = new Random();
        string selectedWord = unusedWords[random.Next(unusedWords.Count)];

        // Add the word to the used words list
        usedWordsByDifficulty[difficulty].Add(selectedWord);

        // Scramble the word
        char[] scrambledArray = selectedWord.ToCharArray();
        random.Shuffle(scrambledArray); // Shuffle the char array

        return new string(scrambledArray);
    }

    // Resets the used words if all words are exhausted
    public void ResetUsedWordsForDifficulty(string difficulty)
    {
        usedWordsByDifficulty[difficulty].Clear();
    }

    // Check if all words for a difficulty have been used
    public bool AllWordsUsed(string difficulty)
    {
        var words = _wordRepository.GetWordsByDifficulty(difficulty);
        return usedWordsByDifficulty[difficulty].Count >= words.Count;
    }
}
}