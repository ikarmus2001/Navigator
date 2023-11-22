namespace SMCEBI_Navigator.Models;

public class Room : BuildingElement
{
    public Room() { }

    public override BuildingElement AddElement()
    {
        throw new ArgumentException($"{nameof(Room)} doesn't have child elements");
    }
}
