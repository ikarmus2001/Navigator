namespace SMCEBI_Navigator.Models;

internal abstract class BuildingElement_Feature
{
    private List<MarkedFeature> markedFeatures;

    internal List<MarkedFeature> MarkedFeatures { get => markedFeatures; }
    internal abstract void AddFeature();
}