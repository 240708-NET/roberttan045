// Room.cs
public class Room
{
    public string Description { get; set; }
    public bool HasEvent { get; set; }
    
    public Room(string description, bool hasEvent)
    {
        Description = description;
        HasEvent = hasEvent;
    }

    public void EnterRoom()
    {
        System.Console.WriteLine(Description);
        if (HasEvent)
        {
            System.Console.WriteLine("Something happens!");
        }
        else
        {
            System.Console.WriteLine("The room is empty.");
        }
    }
}