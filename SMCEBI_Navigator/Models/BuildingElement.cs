namespace SMCEBI_Navigator.Models;

internal abstract class BuildingElement
{
    public string Name;
    public List<BuildingElement_Feature> Features;
    public List<Point> Corners;
    public ElementStyle Style;
}
