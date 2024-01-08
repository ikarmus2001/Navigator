using System.Collections.ObjectModel;

namespace SMCEBI_Navigator.Models;

public class Floor : BuildingElement
{
    public ObservableCollection<Room> Rooms { get; set; }

    public Floor() 
    {
        Rooms = new();
        Features = new();
    }

    public override BuildingElement AddElement()
    {
        Room newChild = new();
        Rooms.Add(newChild);
        return newChild;
    }

}
