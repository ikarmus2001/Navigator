using System.Collections.ObjectModel;

namespace SMCEBI_Navigator.Models;

public class Building : BuildingElement
{
    public uint Version { get; set; } = 0;
    public ObservableCollection<Floor> Floors { get; set; } = new();


    public Building() { }

    internal void AddFloor(Floor newFloor)
    {
        Floors.Add(newFloor);
    }
}
