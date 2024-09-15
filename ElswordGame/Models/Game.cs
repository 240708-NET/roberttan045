public class Game
{
    private List<Character> characters;
    private Player player;
    private Character enemy;

    public Game()
    {
        // Initialize characters
        characters = new List<Character>
        {
            new Player("Elsword", 100, 20),
            new Player("Aisha", 80, 25),
            new Player("Rena", 90, 15)
        };

        // Add skills to characters
        characters[0].AddSkill(new Skill("Sword Slash", 25));
        characters[0].AddSkill(new Skill("Flame Strike", 40));
        characters[1].AddSkill(new Skill("Magic Missile", 30));
        characters[1].AddSkill(new Skill("Fireball", 35));
        characters[2].AddSkill(new Skill("Arrow Shot", 20));
        characters[2].AddSkill(new Skill("Explosive Arrow", 45));
        
        enemy = new Character("Dark Knight", 100, 20);
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Elsword Battle Console App!");

        // Choose character
        Console.WriteLine("Choose your character:");
        for (int i = 0; i < characters.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {characters[i].Name}");
        }
        int choice = int.Parse(Console.ReadLine()) - 1;
        if (choice < 0 || choice >= characters.Count)
        {
            Console.WriteLine("Invalid choice. Exiting.");
            return;
        }
        
        player = (Player)characters[choice];

        Console.WriteLine($"You have selected {player.Name}. Battle starts now!");

        while (player.Health > 0 && enemy.Health > 0)
        {
            Console.WriteLine($"Player Health: {player.Health}, Enemy Health: {enemy.Health}");
            Console.WriteLine("Choose an action: 1. Attack 2. Skill 3. Block 4. Evade");

            var action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    enemy.TakeDamage(player.AttackPower);
                    break;
                case "2":
                    Console.WriteLine("Choose a skill:");
                    for (int i = 0; i < player.Skills.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {player.Skills[i].Name}");
                    }
                    int skillChoice = int.Parse(Console.ReadLine()) - 1;
                    player.UseSkill(skillChoice, enemy);
                    break;
                case "3":
                    Console.WriteLine("You blocked the attack!");
                    break;
                case "4":
                    Console.WriteLine("You evaded the attack!");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (enemy.Health > 0)
            {
                // Simple enemy attack logic
                player.TakeDamage(enemy.AttackPower);
            }
        }

        if (player.Health <= 0)
        {
            Console.WriteLine("Game Over! You have been defeated.");
        }
        else
        {
            Console.WriteLine("Congratulations! You defeated the enemy.");
        }
    }
}