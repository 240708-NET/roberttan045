using System;

public class Reel
{
    private static readonly string[] Symbols = { "Cherry", "Lemon", "Orange", "Bell", "Seven" };
    private static readonly Random Random = new Random();

    public string Spin()
    {
        int index = Random.Next(Symbols.Length);
        return Symbols[index];
    }
}