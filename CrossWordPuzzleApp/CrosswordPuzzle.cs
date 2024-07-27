using System;
using System.Collections.Generic;

public class CrosswordPuzzle
{
    private char[,] grid;
    private int size;

    public CrosswordPuzzle(int size)
    {
        this.size = size;
        grid = new char[size, size];
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                grid[i, j] = '.';
            }
        }
    }

    public bool PlaceWord(string word, int row, int col, bool horizontal)
    {
        if (horizontal)
        {
            if (col + word.Length > size)
                return false;

            for (int i = 0; i < word.Length; i++)
            {
                if (grid[row, col + i] != '.' && grid[row, col + i] != word[i])
                    return false;
            }

            for (int i = 0; i < word.Length; i++)
            {
                grid[row, col + i] = word[i];
            }
        }
        else
        {
            if (row + word.Length > size)
                return false;

            for (int i = 0; i < word.Length; i++)
            {
                if (grid[row + i, col] != '.' && grid[row + i, col] != word[i])
                    return false;
            }

            for (int i = 0; i < word.Length; i++)
            {
                grid[row + i, col] = word[i];
            }
        }

        return true;
    }

    public void Display()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(grid[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}