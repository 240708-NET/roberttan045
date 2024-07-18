namespace GameCore
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Player(string name)
        {
            Name = name;
            Health = 100; // Default health
        }

        public void Attack(Enemy enemy)
        {
            enemy.Health -= 30; // Simple attack logic
            Console.WriteLine($"{Name} attacks {enemy.Name} for 30 damage!");
        }

        public void Defend()
        {
            Console.WriteLine($"{Name} defends!");
        }

        public void MagicAttack(Enemy enemy)
        {
            enemy.Health -= 30; // Simple magic attack logic
            Console.WriteLine($"{Name} casts a spell on {enemy.Name} for 30 damage!");
        }
    }
}