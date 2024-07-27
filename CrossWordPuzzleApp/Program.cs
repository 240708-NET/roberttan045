using System;

class Program
{
    static void Main(string[] args)
    {
        int size = 10; // Define the size of the crossword grid
        CrosswordPuzzle crossword = new CrosswordPuzzle(size);

        // List of words to place in the crossword
        string[] words = { "Hello", "There", "General", "Kenobi", "Power" };

        // Place words in the crossword grid
        crossword.PlaceWord(words[0], 0, 0, true); // horizontal placement
        crossword.PlaceWord(words[1], 2, 0, true);
        crossword.PlaceWord(words[2], 4, 0, true);
        crossword.PlaceWord(words[3], 6, 0, true);
        crossword.PlaceWord(words[4], 8, 0, true);

        // Display the crossword puzzle
        crossword.Display();
    }
}
