using System;

public class SlotMachine
{
    private Reel[] reels;
    private Player player;

    public SlotMachine(Player player)
    {
        this.player = player;
        reels = new Reel[3];  // A simple 3-reel slot machine

        for (int i = 0; i < reels.Length; i++)
        {
            reels[i] = new Reel();
        }
    }

    public void Play(int bet)
    {
        if (bet > player.Balance)
        {
            Console.WriteLine("Insufficient balance.");
            return;
        }

        player.UpdateBalance(-bet);
        string[] results = new string[3];

        for (int i = 0; i < reels.Length; i++)
        {
            results[i] = reels[i].Spin();
        }

        Console.WriteLine($"Spinning... [{results[0]}] [{results[1]}] [{results[2]}]");

        if (results[0] == results[1] && results[1] == results[2])
        {
            int winnings = bet * 10;
            player.UpdateBalance(winnings);
            Console.WriteLine($"Jackpot! You won {winnings} credits!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }

        Console.WriteLine($"Current Balance: {player.Balance}");
    }
}