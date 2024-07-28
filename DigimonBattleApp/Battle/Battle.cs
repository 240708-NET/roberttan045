using System;
using DigimonBattleApp.Digimons;

namespace DigimonBattleApp.Battles
{
    public class Battle
    {
        private Digimon digimon1;
        private Digimon digimon2;

        public Battle(Digimon digimon1, Digimon digimon2)
        {
            this.digimon1 = digimon1;
            this.digimon2 = digimon2;
        }

        public void Start()
        {
            Console.WriteLine($"{digimon1.Name} battles {digimon2.Name}!");
            // Example battle logic
            Console.WriteLine($"{digimon1.Name} uses {digimon1.Moves[0].Name} with power {digimon1.Moves[0].Power}!");
            Console.WriteLine($"{digimon2.Name} uses {digimon2.Moves[0].Name} with power {digimon2.Moves[0].Power}!");
        }
    }
}