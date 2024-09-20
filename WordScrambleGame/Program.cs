using System;
using WordScrambleGame;
using WordScrambleGame.Models;
using WordScrambleGame.Repositories;
using WordScrambleGame.Services;

class Program
{
    static void Main(string[] args)
    {
        var context = new GameContext();
        IWordRepository wordRepository = new WordRepository(context);
        ScrambleManager scrambleManager = new ScrambleManager(wordRepository);

        bool playGame = true;

        while (playGame)
        {
            Console.WriteLine("Select Difficulty Level (1: Easy, 2: Medium, 3: Hard): ");
            string difficulty = Console.ReadLine();

            bool playRound = true;
            while (playRound)
            {
                if (scrambleManager.AllWordsUsed(difficulty))
                {
                    Console.WriteLine("All words for this difficulty have been used.");
                    Console.WriteLine("Do you want to reset the word list and play again? (y/n):");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        scrambleManager.ResetUsedWordsForDifficulty(difficulty); // Reset used words for this difficulty
                    }
                    else
                    {
                        playGame = false;
                        break;
                    }
                }

                string scrambledWord = scrambleManager.GetScrambledWord(difficulty);

                if (scrambledWord == null)
                {
                    Console.WriteLine("No more words available for this difficulty.");
                    Console.WriteLine("Do you want to play a new game? (y/n):");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        scrambleManager.ResetUsedWordsForDifficulty(difficulty); // Reset used words for a new game
                        break; // Exit the current round and start a new game
                    }
                    else
                    {
                        playGame = false;
                        break;
                    }
                }

                Console.WriteLine($"Scrambled Word: {scrambledWord}");
                Console.Write("Your Guess: ");
                string guess = Console.ReadLine();

                if (wordRepository.ValidateWord(difficulty, guess))
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Incorrect. Try again.");
                }

                Console.WriteLine("Play another round? (y/n):");
                if (Console.ReadLine().ToLower() != "y")
                {
                    playRound = false;
                    Console.WriteLine("Do you want to play a new game? (y/n):");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        scrambleManager.ResetUsedWordsForDifficulty(difficulty); // Reset used words for a new game
                    }
                    else
                    {
                        playGame = false;
                    }
                }
            }
        }

        Console.WriteLine("Thank you for playing!");
    }
}