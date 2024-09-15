using System;
using System.Collections.Generic;

public class Player
{
    public string Name { get; set; }
    public List<Tile> Hand { get; private set; }

    public Player(string name)
    {
        Name = name;
        Hand = new List<Tile>();
    }

    public void DrawTile(Tile tile)
    {
        Hand.Add(tile);
    }

    public void DiscardTile(int index)
    {
        if (index >= 0 && index < Hand.Count)
        {
            Hand.RemoveAt(index);
        }
    }

    public void ShowHand()
    {
        Console.WriteLine($"{Name}'s Hand:");
        foreach (var tile in Hand)
        {
            Console.WriteLine(tile);
        }
    }
}