namespace CardBattleGame.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int ManaCost { get; set; }
        public string Ability { get; set; }

        public Card(string name, int attack, int defense, int manaCost, string ability)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
            ManaCost = manaCost;
            Ability = ability;
        }

        public override string ToString()
        {
            return $"{Name} - ATK: {Attack}, DEF: {Defense}, Cost: {ManaCost}, Ability: {Ability}";
        }
    }
}