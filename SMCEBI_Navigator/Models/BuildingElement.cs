namespace SMCEBI_Navigator.Models;

internal abstract class BuildingElement
{
    private List<BuildingElement_Feature> features;
    private List<System.Drawing.Point> corners;
    private ElementStyle style;

    protected List<System.Drawing.Point> Corners { get => corners; }

    internal void AddCorner(System.Drawing.Point corner) => corners.Add(corner);
}
