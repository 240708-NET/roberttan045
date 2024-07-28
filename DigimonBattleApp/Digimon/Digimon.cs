using System.Collections.Generic;
using DigimonBattleApp.Moves;

namespace DigimonBattleApp.Digimons
{
    public class Digimon
    {
        public string Name { get; set; }
        public List<Move> Moves { get; set; }

        public Digimon(string name, List<Move> moves)
        {
            Name = name;
            Moves = moves;
        }

        public void DisplayMoves()
        {
            System.Console.WriteLine($"{Name}'s Moves:");
            for (int i = 0; i < Moves.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}. {Moves[i].Name} (Power: {Moves[i].Power})");
            }
        }
    }
}