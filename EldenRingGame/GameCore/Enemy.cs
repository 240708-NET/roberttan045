namespace GameCore
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Enemy(string name)
        {
            Name = name;
            Health = 100; // Default health
        }

        public void Attack(Player player)
        {
            player.Health -= 25; // Simple attack logic
            Console.WriteLine($"{Name} attacks {player.Name} for 25 damage!");
        }
    }
}