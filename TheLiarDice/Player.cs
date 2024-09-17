using System;
using System.Collections.Generic;

public class Player
{
    public string Name { get; set; }
    public List<Die> Dice { get; private set; }
    public bool IsOut => Dice.Count == 0;
    public bool IsCPU { get; set; }

    public Player(string name, bool isCPU = false)
    {
        Name = name;
        IsCPU = isCPU;
        Dice = new List<Die> { new Die(), new Die(), new Die(), new Die(), new Die() };
    }

    public void RollDice()
    {
        foreach (var die in Dice)
        {
            die.Roll();
        }
    }

    public void RemoveDie()
    {
        if (Dice.Count > 0)
        {
            Dice.RemoveAt(Dice.Count - 1);
        }
    }
}