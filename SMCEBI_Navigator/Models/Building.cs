using System.Collections.ObjectModel;

namespace SMCEBI_Navigator.Models;

public class Building : BuildingElement, IBuildingElementOperations
{
    public uint Version { get; set; } = 0;
    public ObservableCollection<Floor> Floors { get; set; } = new();


    public Building() 
    {
        Features = new();
    }

    public override BuildingElement AddElement()
    {
        Floor newChild = new();
        Floors.Add(newChild);
        return newChild;
    }
}
