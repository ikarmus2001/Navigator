using MapBuilder_API_Base;

namespace SMCEBI_Navigator.Models;

public abstract class BuildingElement
{
    public string Name { get; set; } = "<Empty name>";
    public List<MarkedFeature> Features { get; set; } = new();
    public List<PointClass> Corners { get; set; } = new();
    public ElementStyle Style { get; set; } = new();
}