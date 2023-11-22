using MapBuilder_API_Base;
using System.Collections.ObjectModel;

namespace SMCEBI_Navigator.Models;

public abstract class BuildingElement : IBuildingElementOperations
{
    public string Name { get; set; } = "<Empty name>";
    public ObservableCollection<MarkedFeature> Features { get; set; } = new();
    public ObservableCollection<PointClass> Corners { get; set; } = new();
    public ElementStyle Style { get; set; } = new();

    public abstract BuildingElement AddElement();
}

public interface IBuildingElementOperations
{
    public BuildingElement AddElement();
}