using System;
using System.Collections.Generic;

public class Board
{
    private List<Tile> tiles;
    private Random random;

    public Board()
    {
        tiles = new List<Tile>();
        random = new Random();

        // Initialize tiles (simple version with just suits and numbers)
        string[] suits = { "Bamboo", "Character", "Dot" };
        for (int i = 1; i <= 9; i++)
        {
            foreach (var suit in suits)
            {
                for (int j = 0; j < 4; j++) // Each tile appears 4 times in Mahjong
                {
                    tiles.Add(new Tile(suit, i));
                }
            }
        }
    }

    public Tile DrawTile()
    {
        if (tiles.Count > 0)
        {
            int index = random.Next(tiles.Count);
            Tile drawnTile = tiles[index];
            tiles.RemoveAt(index);
            return drawnTile;
        }
        return null;
    }
}