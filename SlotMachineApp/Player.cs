public class Player
{
    public string Name { get; set; }
    public int Balance { get; set; }

    public Player(string name, int initialBalance)
    {
        Name = name;
        Balance = initialBalance;
    }

    public void UpdateBalance(int amount)
    {
        Balance += amount;
    }
}