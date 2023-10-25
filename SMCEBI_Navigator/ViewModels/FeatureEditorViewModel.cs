using CommunityToolkit.Mvvm.ComponentModel;
using SMCEBI_Navigator.Models;
using FA = SMCEBI_Navigator.ViewModels.FeatureAction;

namespace SMCEBI_Navigator.ViewModels;

internal partial class FeatureEditorViewModel : ObservableObject
{
    internal Building buildingRef;
    [ObservableProperty] private string featureName;

    [ObservableProperty] private string pageTitle;

    readonly FA action;
    [ObservableProperty] public BuildingElement editorElement;
    [ObservableProperty] public List<BuildingElement> childElements;
    [ObservableProperty] public List<BuildingElement_Feature> markedFeatures;

    [ObservableProperty] public bool isSizePickerVisible = true;
    [ObservableProperty] public bool isStylePickerVisible = true;
    [ObservableProperty] public bool isPreviewVisible = false;

    public FeatureEditorViewModel(IDictionary<string, object> query)
    {
        buildingRef = query[nameof(Building)] as Building;
        EditorElement = query[nameof(BuildingElement)] as BuildingElement;
        action = (FA)Enum.Parse(typeof(FA), query[nameof(FA)].ToString());
        PrepareContent();
    }

    private void PrepareContent()
    {
        Action p = EditorElement switch
        {
            Building => PrepareBuilding,
            Floor => PrepareFloor,
            Room => PrepareRoom,
            MarkedFeature => PrepareFeature,
            _ => throw new NotImplementedException()
        };
        p();

        PageTitle = $"{Enum.GetName(typeof(FA), action)} {FeatureName}";
    }

    private void PrepareBuilding()
    {
        FeatureName = "Building";
        ChildElements = (EditorElement as Building).Floors.Cast<BuildingElement>().ToList();

        IsSizePickerVisible = false;
        IsStylePickerVisible = false;
    }

    private void PrepareFeature()
    {
        FeatureName = "Feature";
        MarkedFeatures = (EditorElement as MarkedFeature).Features;
    }

    private void PrepareRoom()
    {
        FeatureName = "Room";
        ChildElements = null;
        MarkedFeatures = (EditorElement as Room).Features;
        IsPreviewVisible = true;
    }

    private void PrepareFloor()
    {
        FeatureName = "Floor";
        ChildElements = (EditorElement as Floor).Rooms.Cast<BuildingElement>().ToList();
        MarkedFeatures = (EditorElement as Floor).Features;

        IsSizePickerVisible = false;
        IsStylePickerVisible = false;
    }

    internal void AddChild()
    {
        BuildingElement newChild = EditorElement switch
        {
            Building => new Floor(),
            Floor => new Room(),
            Room => new MarkedFeature(),
            _ => throw new NotImplementedException()
        };

        ChildElements.Add(newChild);
    }
}
