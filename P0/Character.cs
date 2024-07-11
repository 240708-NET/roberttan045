// Charcter.cs

public class Character
{

    public string Name { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }


    public Character(string name)
    {
        Name = name;
        Health = 100;
        Strength = 10;
        Agility = 10;
    }


    public void DisplayStats()
    {
        System.Console.WriteLine($"Name: {Name}");
        System.Console.WriteLine($"Health: {Health}");
        System.Console.WriteLine($"Strength: {Strength}");
        System.Console.WriteLine($"Agility: {Agility}");
    }
