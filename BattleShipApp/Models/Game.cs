namespace BattleShipApp.Models
{
public class Game
{
    public int Id { get; set; }
    public int Player1Id { get; set; }
    public Player Player1 { get; set; }
    public int Player2Id { get; set; }
    public Player Player2 { get; set; }
    public bool IsPlayer1Turn { get; set; }
    public DateTime StartTime { get; set; }
  }
}
