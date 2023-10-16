namespace SMCEBI_Navigator.Models;

public abstract class BuildingElement
{
    public string Name { get; set; }
    public List<BuildingElement_Feature> Features;
    public List<Point> Corners { get; set; }
    public ElementStyle Style { get; set; }
}
