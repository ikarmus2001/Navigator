namespace SMCEBI_Navigator.Models;

public class MarkedFeature : BuildingElement
{
    public MarkedFeature() { }

    public override BuildingElement AddElement()
    {
        MarkedFeature newChild = new();
        Features.Add(newChild);
        return newChild;
    }
}