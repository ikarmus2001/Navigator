using CommunityToolkit.Mvvm.ComponentModel;
using SMCEBI_Navigator.Models;

namespace SMCEBI_Navigator.ViewModels;

internal partial class FeatureEditorViewModel : ObservableObject
{
    internal Building buildingRef;
    [ObservableProperty] private string featureName;

    [ObservableProperty] private string pageTitle;

    FeatureAction action;
    [ObservableProperty] public BuildingElement editorElement;

    [ObservableProperty] public List<BuildingElement> childElements;

    [ObservableProperty] public List<BuildingElement_Feature> markedFeatures;

    [ObservableProperty] public bool isSizePickerVisible = true;
    [ObservableProperty] public bool isStylePickerVisible = true;
    

    //internal delegate Action<BuildingElement> SaveDelegate();

    //internal event Action<BuildingElement> SaveEvent;

    public FeatureEditorViewModel(IDictionary<string, object> query)
    {
        buildingRef = query[nameof(Building)] as Building;
        EditorElement = query[nameof(BuildingElement)] as BuildingElement;
        //action = (FeatureAction)Enum.Parse(typeof(FeatureAction), query[nameof(FeatureAction)].ToString());
        PrepareContent(query[nameof(Type)] as Type);
    }

    private void PrepareContent(Type elementType)
    {
        // TODO IK it look awful, cant find suitable syntax for type pattern matching switch
        if (elementType == typeof(Floor))
        {
            PrepareFloor();
        }
        else if (elementType == typeof(Room))
        {
            PrepareRoom();
        }
        else if (elementType == typeof(MarkedFeature))
        {
            PrepareFeature();
        }
        PageTitle = $"{Enum.GetName(typeof(FeatureAction), action)} {FeatureName}";
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
    }

    private void PrepareFloor()
    {
        FeatureName = "Floor";
        ChildElements = (EditorElement as Floor).Rooms.Cast<BuildingElement>().ToList();
        MarkedFeatures = (EditorElement as Floor).Features;

        IsSizePickerVisible = false;
        IsStylePickerVisible = false;
    }

    internal void Save()
    {
        
    }

    //internal async Task<bool> Save()
    //{
    //    if (action == FeatureAction.Add)
    //    {

    //    }
    //    return true;
    //}
}
