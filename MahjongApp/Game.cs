using System;

public class Game
{
    private Board board;
    private Player player1;
    private Player player2;

    public Game()
    {
        board = new Board();
        player1 = new Player("Player 1");
        player2 = new Player("Player 2");
    }

    public void Start()
    {
        Console.WriteLine("Starting Mahjong Game...");

        // Initial draw for each player
        for (int i = 0; i < 13; i++)
        {
            player1.DrawTile(board.DrawTile());
            player2.DrawTile(board.DrawTile());
        }

        player1.ShowHand();
        player2.ShowHand();
    }
}