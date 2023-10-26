namespace SMCEBI_Navigator.Models;

public class Floor : BuildingElement
{
    public List<Room> Rooms { get; set; }

    public Floor() 
    {
        Rooms = new();
    }

}
