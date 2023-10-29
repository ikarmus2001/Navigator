using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using SMCEBI_Navigator.Models;
using SMCEBI_Navigator.Views;
using System.Collections.ObjectModel;
using FA = SMCEBI_Navigator.ViewModels.FeatureAction;

namespace SMCEBI_Navigator.ViewModels;

internal partial class FeatureEditorViewModel : ObservableObject
{
    private readonly INavigation navi;
    

    [ObservableProperty] private string featureName;
    [ObservableProperty] private string pageTitle;

    private readonly FA action;
    private readonly Building buildingRef;
    [ObservableProperty] public BuildingElement editorElement;
    public ObservableCollection<BuildingElement> ChildElements { get; set; }
    [ObservableProperty] public IEnumerable<MarkedFeature> markedFeatures;

    [ObservableProperty] public bool isSizePickerVisible = true;
    [ObservableProperty] public bool isStylePickerVisible = true;
    [ObservableProperty] public bool isPreviewVisible = false;

    [ObservableProperty] public string childName;

    public FeatureEditorViewModel(IDictionary<string, object> query, INavigation navi)
    {
        buildingRef = query[nameof(Building)] as Building;
        EditorElement = query[nameof(BuildingElement)] as BuildingElement;
        action = (FA)Enum.Parse(typeof(FA), query[nameof(FA)].ToString());
        PrepareContent();
        this.navi = navi;
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
        FeatureName = nameof(Building);
        ChildName = nameof(Floor);
        ChildElements = (EditorElement as Building).Floors.ToObservableCollection<BuildingElement>();

        IsSizePickerVisible = false;
        IsStylePickerVisible = false;
    }

    private void PrepareFeature()
    {
        FeatureName = "Feature";
        ChildName = "Subfeature";
        MarkedFeatures = (EditorElement as MarkedFeature).Features;
    }

    private void PrepareRoom()
    {
        FeatureName = "Room";
        ChildName = null;
        ChildElements = null;
        MarkedFeatures = (EditorElement as Room).Features;
        IsPreviewVisible = true;
    }

    private void PrepareFloor()
    {
        FeatureName = "Floor";
        ChildName = nameof(Room);
        ChildElements = (EditorElement as Floor).Rooms.ToObservableCollection<BuildingElement>();
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
            _ => throw new NotImplementedException()
        };
        ChildElements.Add(newChild);
    }

    internal void AddFeature()
    {
        _ = MarkedFeatures.Append(new MarkedFeature());
    }

    internal async Task GoToEditor(BuildingElement element, FA fa=FA.Modify) =>
        await navi.PushAsync(new FeatureEditorPage(ObjectExtensions.NavigationParams(buildingRef, element, fa)));
}
