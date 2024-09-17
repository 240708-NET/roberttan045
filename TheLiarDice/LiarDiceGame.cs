using System;
using System.Collections.Generic;
using System.Linq;

public class LiarDiceGame
{
    private List<Player> _players;
    private int _currentPlayerIndex;
    private int _currentBidFace;
    private int _currentBidQuantity;

    public LiarDiceGame(List<Player> players)
    {
        _players = players;
        _currentPlayerIndex = 0;
    }

    public void StartGame()
    {
        while (_players.Count(p => !p.IsOut) > 1)
        {
            PlayRound();
        }

        Console.WriteLine($"{_players.First(p => !p.IsOut).Name} wins the game!");
    }

    private void PlayRound()
    {
        // Roll dice for all players
        foreach (var player in _players)
        {
            if (!player.IsOut)
            {
                player.RollDice();
            }
        }

        // Show the dice values of each player
        ShowPlayerDice();

        _currentBidFace = 0;
        _currentBidQuantity = 0;

        Console.WriteLine("New round started. Players, make your bids!");

        bool roundOver = false;
        while (!roundOver)
        {
            var currentPlayer = _players[_currentPlayerIndex];
            if (currentPlayer.IsOut)
            {
                MoveToNextPlayer();
                continue;
            }

            // Check if it's the CPU's turn
            if (currentPlayer.IsCPU)
            {
                HandleCPUTurn(currentPlayer);
            }
            else
            {
                // Human player's turn
                Console.WriteLine($"{currentPlayer.Name}'s turn.");
                Console.WriteLine($"Current bid: {_currentBidQuantity} of face {_currentBidFace}");
                Console.WriteLine("Enter 'bid' to make a bid or 'liar' to challenge:");
                var input = Console.ReadLine();

                if (input.ToLower() == "bid")
                {
                    Console.WriteLine("Enter bid face (1-6):");
                    int bidFace = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter bid quantity:");
                    int bidQuantity = int.Parse(Console.ReadLine());

                    if (IsValidBid(bidFace, bidQuantity))
                    {
                        _currentBidFace = bidFace;
                        _currentBidQuantity = bidQuantity;
                        MoveToNextPlayer();
                    }
                    else
                    {
                        Console.WriteLine("Invalid bid. Try again.");
                    }
                }
                else if (input.ToLower() == "liar")
                {
                    roundOver = HandleLiar(currentPlayer);
                }
            }

            // Check if round is over
            roundOver = roundOver || _players.Count(p => !p.IsOut) <= 1;
        }
    }

    // Place HandleCPUTurn directly inside the LiarDiceGame class, not inside another method
    private void HandleCPUTurn(Player cpuPlayer)
    {
        Random random = new Random();

        // Simple CPU logic: 70% chance to make a bid, 30% chance to call "liar"
        int action = random.Next(0, 100);
        if (action < 70)
        {
            // Make a bid: Randomly choose face and quantity based on current game state
            int newBidFace = random.Next(1, 7);
            int newBidQuantity = _currentBidQuantity + random.Next(1, 3); // Increase quantity by 1 or 2

            // Check if the bid is valid
            if (IsValidBid(newBidFace, newBidQuantity))
            {
                _currentBidFace = newBidFace;
                _currentBidQuantity = newBidQuantity;
                Console.WriteLine($"{cpuPlayer.Name} bids {newBidQuantity} of face {newBidFace}.");
            }
            else
            {
                // If invalid bid is generated, just pass the turn without changing the bid
                Console.WriteLine($"{cpuPlayer.Name} passes its turn.");
            }
        }
        else
        {
            // Call "liar"
            Console.WriteLine($"{cpuPlayer.Name} calls 'Liar'!");
            HandleLiar(cpuPlayer);
        }

        MoveToNextPlayer();
    }

    private void ShowPlayerDice()
    {
        Console.WriteLine("\nCurrent dice values for each player:");
        foreach (var player in _players)
        {
            if (!player.IsOut)
            {
                Console.Write($"{player.Name}: ");
                foreach (var die in player.Dice)
                {
                    Console.Write($"{die.FaceValue} ");
                }
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }

    private bool IsValidBid(int bidFace, int bidQuantity)
    {
        if (bidFace < 1 || bidFace > 6)
        {
            return false;
        }

        // Allow bids with higher quantity, or with the same quantity but higher face value
        if (bidQuantity > _currentBidQuantity ||
            (bidQuantity == _currentBidQuantity && bidFace > _currentBidFace))
        {
            return true;
        }

        return false;
    }

    private void MoveToNextPlayer()
    {
        _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
    }

    private bool HandleLiar(Player challenger)
{
    var lastBidPlayer = _players[(_currentPlayerIndex - 1 + _players.Count) % _players.Count];
    int totalFaceCount = CountDiceWithFace(_currentBidFace);

    Console.WriteLine($"Total dice with face {_currentBidFace}: {totalFaceCount}");
    Console.WriteLine($"{challenger.Name} called 'Liar'!");

    // Determine if the last bid was a lie
    if (totalFaceCount < _currentBidQuantity)
    {
        Console.WriteLine($"{lastBidPlayer.Name} was lying! They lose a die.");
        lastBidPlayer.RemoveDie();
    }
    else
    {
        Console.WriteLine($"{challenger.Name} was wrong! They lose a die.");
        challenger.RemoveDie();
    }

    // Check if any player is out of dice
    if (lastBidPlayer.IsOut)
    {
        Console.WriteLine($"{lastBidPlayer.Name} is out of the game!");
    }
    if (challenger.IsOut)
    {
        Console.WriteLine($"{challenger.Name} is out of the game!");
    }

    // End the round and prepare for the next round
    return true;
}

private int CountDiceWithFace(int face)
{
    int count = 0;
    foreach (var player in _players)
    {
        if (!player.IsOut)
        {
            count += player.Dice.Count(die => die.FaceValue == face);
        }
    }
    return count;
}
}