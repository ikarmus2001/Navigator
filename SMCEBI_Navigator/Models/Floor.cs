namespace SMCEBI_Navigator.Models;

internal class Floor : BuildingElement
{
    private List<Room> rooms;

    internal string Name;
    internal List<Room> Rooms { get => rooms; }

    public Floor(string name)
    {
        Name = name;
        rooms = new List<Room>();
    }

    internal void AddRoom(Room newRoom) => rooms.Add(newRoom);

}
